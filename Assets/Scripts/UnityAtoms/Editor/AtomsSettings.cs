using UnityEditor;
using UnityEngine;

namespace UnityAtoms
{
    public class AtomsSettings : ScriptableObject
    {
        public static string atomSettingsPath = "Assets/Editor/UnityAtomsSettings.asset";
        public string atomCreatePath = "Assets/";

        private static AtomsSettings instance;
        public static AtomsSettings Instance
        {
            get
            {
                return GetOrCreateSettings();
            }
        }

        internal static AtomsSettings GetOrCreateSettings()
        {
            var settings = AssetDatabase.LoadAssetAtPath<AtomsSettings>(atomSettingsPath);
            if (settings == null)
            {
                settings = ScriptableObject.CreateInstance<AtomsSettings>();
                settings.atomCreatePath = "Assets/";
                AssetDatabase.CreateAsset(settings, atomSettingsPath);
                AssetDatabase.SaveAssets();
            }
            return settings;
        }

        internal static SerializedObject GetSerializedSettings()
        {
            return new SerializedObject(GetOrCreateSettings());
        }
    }
}
