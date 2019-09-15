using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System;
using Object = UnityEngine.Object;
using UnityEditor.Animations;

namespace UnityAtoms.Editor
{
    using Editor = UnityEditor.Editor;
	public class ReferenceDataEditor : Editor
    {
        protected Texture2D iconGo { get; private set; }
        protected Texture2D iconAsset { get; private set; }
        protected Texture2D iconAnimatorController { get; private set; }

        GUIStyle labelStyle;

        private void OnEnable()
        {
            iconGo = EditorGUIUtility.IconContent("GameObject Icon").image as Texture2D;
            iconAsset = EditorGUIUtility.IconContent("Prefab Icon").image as Texture2D;
            iconAnimatorController = EditorGUIUtility.IconContent("AnimatorController Icon").image as Texture2D;
        }

        public override void OnInspectorGUI()
        {
            RefData atomBase = (RefData)target as RefData;

            if (labelStyle == null)
                labelStyle = new GUIStyle(EditorStyles.largeLabel);

            labelStyle.fontSize = 24;

            GUILayout.Label(atomBase.name, labelStyle);

            base.OnInspectorGUI();

            GUI.enabled = true;

            DrawReferenes(atomBase);
        }

        void DrawReferenes(RefData atomBase)
        {
            EditorGUILayout.Space();
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            EditorGUILayout.LabelField("References", EditorStyles.largeLabel);

            if (GUILayout.Button("Refresh"))
            {
                PopulateRefs(atomBase.refs);
            }

            EditorGUILayout.Space();
            Color gbc = GUI.backgroundColor;
            GUIStyle goName = new GUIStyle(EditorStyles.largeLabel);
            goName.fontStyle = FontStyle.Bold;
            goName.alignment = TextAnchor.MiddleLeft;
            foreach (var @ref in atomBase.refs)
            {
                EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                {
                    EditorGUILayout.BeginHorizontal();
                    {
                        GUIContent icon = null;
                        if (@ref.Key is GameObject)
                        {
                            icon = new GUIContent(iconGo, nameof(GameObjectVariable));
                        }
                        else
                        {
                            icon = new GUIContent(iconAsset, "Asset");
                        }
                        if (@ref.Key is AnimatorController)
                        {
                            icon = new GUIContent(iconAnimatorController, "AnimatorController");
                        }
                        if (@ref.Key is ScriptableObject)
                        {
                            string path = AssetDatabase.GetAssetPath(@ref.Key);
                            icon = new GUIContent(AssetDatabase.GetCachedIcon(path), "ScriptableObject");
                        }
                        EditorGUILayout.LabelField(icon, GUILayout.Width(30), GUILayout.Height(25), GUILayout.ExpandHeight(true));
                        EditorGUILayout.BeginVertical();
                        {
                            if (@ref.Key != null && @ref.Value != null)
                            {
                                EditorGUILayout.LabelField($"{@ref.Key.name}", goName,
                                    GUILayout.MinWidth(100), GUILayout.ExpandHeight(true));
                                EditorGUILayout.LabelField($"└ {@ref.Value.Name}", EditorStyles.boldLabel,
                                    GUILayout.MinWidth(100), GUILayout.ExpandHeight(true));
                            }
                            else
                            {
                                EditorGUILayout.LabelField("Destroyed", goName,
                                   GUILayout.MinWidth(100), GUILayout.ExpandHeight(true));
                            }
                        }
                        EditorGUILayout.EndVertical();
                        GUI.backgroundColor = Color.cyan;
                        if (GUILayout.Button("Select", GUILayout.MaxWidth(55), GUILayout.ExpandHeight(true)))
                        {
                            Selection.activeObject = @ref.Key;
                        }
                        GUI.backgroundColor = Color.green;
                        if (GUILayout.Button("Ping", GUILayout.MaxWidth(55), GUILayout.ExpandHeight(true)))
                        {
                            EditorGUIUtility.PingObject(@ref.Key);
                        }
                        GUI.enabled = true;
                        GUI.backgroundColor = gbc;
                    }
                    EditorGUILayout.EndHorizontal();
                }
                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.EndVertical();
        }

        void PopulateRefs(Dictionary<Object, Type> refs)
        {
            refs.Clear();
            List<Object> allSceneObjects = new List<Object>();
            allSceneObjects.AddRange(FindObjectsOfType<GameObject>());
            allSceneObjects.AddRange(FindObjectsOfType<Animator>());
            int length = allSceneObjects.Count;
            allSceneObjects.AddRange(FindObjectsOfType<ScriptableObject>());
            BrowseObjects(allSceneObjects.ToArray(), length, refs);
            List<Object> allObjects = new List<Object>();
            allObjects.AddRange(Resources.FindObjectsOfTypeAll<GameObject>());
            allObjects.AddRange(Resources.FindObjectsOfTypeAll<Animator>());
            length = allObjects.Count;
            BrowseObjects(allObjects.ToArray(), length, refs);
            ScriptableObject[] scriptableObj = GetAllInstances<ScriptableObject>();
            length = scriptableObj.Length;
            BrowseObjects(scriptableObj, length, refs);
        }

        void BrowseObjects(Object[] objets, int length, Dictionary<Object, Type> refs)
        {
            for (int o = length - 1; o >= 0; --o)
            {
                var obj = objets[o];

                if (obj is GameObject)
                {
                    var go = (GameObject)obj as GameObject;
                    var components = go.GetComponents<Component>();
                    for (int i = 0; i < components.Length; i++)
                    {
                        var component = components[i];
                        if (component == null) continue;

                        FindReferenceInField(component, component, refs);
                    }
                }
                if (obj is Animator)
                {
                    var animator = (Animator)obj as Animator;
                    AnimatorController controller = animator.runtimeAnimatorController as AnimatorController;
                    if (controller == null) continue;

                    foreach (AnimatorControllerLayer layer in controller.layers)
                    {
                        foreach (ChildAnimatorState childAnimState in layer.stateMachine.states)
                        {
                            foreach (StateMachineBehaviour smb in childAnimState.state.behaviours)
                            {
                                FindReferenceInField(controller, smb, refs);
                            }
                        }
                    }
                }

                if (obj is ScriptableObject)
                {
                    var sObj = obj as ScriptableObject;

                    FindReferenceInField(sObj, sObj, refs);
                }
            }
        }

        void FindReferenceInField<T, U>
            (T o, U type, Dictionary<Object, Type> references)
            where T : Object
        {
            var so = new SerializedObject(o);
            var sp = so.GetIterator();

            while (sp.NextVisible(true))
            {
                if (sp.propertyType == SerializedPropertyType.ObjectReference)
                {
                    if (sp.objectReferenceValue == this.target)
                    {
                        if (!references.ContainsKey(o))
                            references.Add(o, type.GetType());
                    }
                }

                bool isUnityEvent = HasReferenceInUnityEvent(sp);
                if (isUnityEvent)
                    if (!references.ContainsKey(o))
                        references.Add(o, type.GetType());
            }
        }

        public static T[] GetAllInstances<T>() where T : ScriptableObject
        {
            string[] guids = AssetDatabase.FindAssets("t:" + typeof(T).Name);  //FindAssets uses tags check documentation for more info
            int length = guids.Length;
            T[] a = new T[length];
            for (int i = length - 1; i >= 0; i--)
            {
                string path = AssetDatabase.GUIDToAssetPath(guids[i]);
                a[i] = AssetDatabase.LoadAssetAtPath<T>(path);
            }
            return a;
        }

        bool HasReferenceInUnityEvent(SerializedProperty sp)
        {
            bool IsTarget(SerializedProperty serializedProperty) => serializedProperty
                    .FindPropertyRelative("m_Target").objectReferenceValue == this.target ? true : false;

            bool IsArgument(SerializedProperty serializedProperty) => serializedProperty
                    .FindPropertyRelative("m_Arguments")
                    .FindPropertyRelative("m_ObjectArgument").objectReferenceValue == this.target ? true : false;

            SerializedProperty persistentCalls = sp.FindPropertyRelative("m_PersistentCalls.m_Calls");
            if (persistentCalls == null) return false;
            for (int u = persistentCalls.arraySize - 1; u >= 0; --u)
            {
                if (IsTarget(persistentCalls.GetArrayElementAtIndex(u)) || IsArgument(persistentCalls.GetArrayElementAtIndex(u)))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
