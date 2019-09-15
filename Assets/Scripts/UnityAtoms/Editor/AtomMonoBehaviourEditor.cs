using UnityEngine;
using UnityEditor;
using Object = UnityEngine.Object;
using UnityEditor.Animations;
using System.Collections.Generic;
using System;

namespace UnityAtoms.Editor
{
	using Editor = UnityEditor.Editor;
	[CustomEditor(typeof(AtomMonoBehaviour), true), CanEditMultipleObjects]
	public class AtomMonoBehaviourEditor : Editor
	{
		GUIStyle labelStyle;
		GUIStyle noteStyle;
        protected Texture2D iconGo { get; private set; }
        protected Texture2D iconAsset { get; private set; }
        protected Texture2D iconAnimatorController { get; private set; }

        private void OnEnable()
        {
            iconGo = EditorGUIUtility.IconContent("GameObject Icon").image as Texture2D;
            iconAsset = EditorGUIUtility.IconContent("Prefab Icon").image as Texture2D;
            iconAnimatorController = EditorGUIUtility.IconContent("AnimatorController Icon").image as Texture2D;
        }

        public override void OnInspectorGUI()
		{
			DrawNote();

            AtomMonoBehaviour atomMonoBehavior = (AtomMonoBehaviour)target as AtomMonoBehaviour;

            DrawReference(atomMonoBehavior);

			base.OnInspectorGUI();
		}

		void DrawNote()
		{
			serializedObject.Update();

			SerializedProperty note = serializedObject.FindProperty("note");
			EditorGUI.BeginChangeCheck();
			EditorGUILayout.BeginHorizontal();
			{
				if (labelStyle == null)
					labelStyle = new GUIStyle(EditorStyles.label);
				labelStyle.fontSize = 10;
				labelStyle.fontStyle = FontStyle.Bold;
				labelStyle.alignment = TextAnchor.MiddleLeft;
				labelStyle.normal.textColor = new Color(0.1840513f, 0.6320387f, 0.7301887f, 1f);
				if (noteStyle == null)
					noteStyle = new GUIStyle(EditorStyles.textField);
				noteStyle.fontStyle = FontStyle.Italic;
				EditorGUILayout.LabelField("Dev note", labelStyle, GUILayout.MaxWidth(64));
				note.stringValue = EditorGUILayout.TextField(note.stringValue, noteStyle, GUILayout.ExpandWidth(true));
			}
			EditorGUILayout.EndHorizontal();

			if (EditorGUI.EndChangeCheck())
			{
				EditorUtility.SetDirty(serializedObject.targetObject);
				serializedObject.ApplyModifiedProperties();
			}
		}

        void DrawReference(AtomMonoBehaviour atomBase)
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.LabelField("References", EditorStyles.boldLabel);

                if (GUILayout.Button("Refresh", EditorStyles.miniButton))
                {
                    PopulateRefs(atomBase.refs);
                }
            }
            EditorGUILayout.EndHorizontal();

            Color gbc = GUI.backgroundColor;
            GUIStyle goName = new GUIStyle(EditorStyles.label);
            goName.wordWrap = true;
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

                        if (@ref.Key != null && @ref.Value != null)
                        {
                            EditorGUILayout.LabelField(icon, GUILayout.Width(30), GUILayout.ExpandHeight(true));
                            EditorGUILayout.LabelField($"{@ref.Key.name}\n└ {@ref.Value.Name}", goName,
                                GUILayout.MinWidth(100), GUILayout.ExpandHeight(true));
                        }
                        else
                        {
                            EditorGUILayout.LabelField("Destroyed", goName,
                               GUILayout.MinWidth(100), GUILayout.ExpandHeight(true));
                        }

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
            var allObjects = Object.FindObjectsOfType<Object>();
            int length = allObjects.Length;
            for (int j = 0; j < length; j++)
            {
                var obj = allObjects[j];

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
