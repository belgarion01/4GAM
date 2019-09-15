using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace UnityAtoms
{
    class AtomsSettingsProvider : SettingsProvider
    {
        private SerializedObject settings;

        class Styles
        {
            public static GUIContent atomCreatePath = new GUIContent(" Atom Create Path");
        }

        public AtomsSettingsProvider(string path, SettingsScope scope = SettingsScope.User)
            : base(path, scope) { }

        public static bool IsSettingsAvailable()
        {
            return File.Exists(AtomsSettings.atomSettingsPath);
        }

        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            settings = AtomsSettings.GetSerializedSettings();
        }

        public override void OnGUI(string searchContext)
        {
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(settings.FindProperty("atomCreatePath"), Styles.atomCreatePath);

            EditorGUI.EndChangeCheck();
            if (GUI.changed)
            {
                settings.ApplyModifiedProperties();
            }
        }

        // Register the SettingsProvider
        [SettingsProvider]
        public static SettingsProvider CreateAtomSettingsProvider()
        {
            if (IsSettingsAvailable())
            {
                var provider = new AtomsSettingsProvider("Project/Unity Atoms", SettingsScope.Project);

                // Automatically extract all keywords from the Styles.
                provider.keywords = GetSearchKeywordsFromGUIContentProperties<Styles>();
                return provider;
            }
            // Settings Asset doesn't exist yet; no need to display anything in the Settings window.
            return null;
        }
    }

}
