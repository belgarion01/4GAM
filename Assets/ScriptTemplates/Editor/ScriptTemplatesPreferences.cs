using System;
using System.Collections.Generic;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace ScriptTemplates.Editor
{
	static class ScriptTemplatesPreferences
	{
		public static string comment = "";
		private static bool prefsLoaded = false;

		[SettingsProvider]
		public static SettingsProvider CreateScriptTemplatesPreferencesProvider()
		{
			// First parameter is the path in the Settings window.
			// Second parameter is the scope of this setting: it only appears in the Project Settings window.
			var provider = new SettingsProvider("Preferences/ScriptTemplatesPreferences", SettingsScope.User)
			{
				// By default the last token of the path is used as display name if no label is provided.
				label = "Script Templates",
				// Create the SettingsProvider and initialize its drawing (IMGUI) function in place:
				guiHandler = (searchContext) =>
				{
					if (!prefsLoaded)
					{
						comment = EditorPrefs.GetString("commentKey", string.Empty);
						prefsLoaded = true;
					}

					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.AppendLine($"#COMMENT# - Script path");
					stringBuilder.AppendLine($"#CREATIONDATE# - {DateTime.Now}");
					stringBuilder.AppendLine($"#PROJECTNAME# - {PlayerSettings.productName}");
					stringBuilder.AppendLine($"#DEVELOPERS# - {PlayerSettings.companyName}");
					stringBuilder.AppendLine($"#NAMESPACE# - {"Game"}");
					stringBuilder.Append($"#PATH# - Comment bellow");
					EditorGUILayout.HelpBox(stringBuilder.ToString(), MessageType.Info, true);

					EditorGUILayout.LabelField("Comment");
					comment = EditorGUILayout.TextArea(comment, GUILayout.MinHeight(32), GUILayout.MaxHeight(128));

					if (GUI.changed)
						EditorPrefs.SetString("commentKey", comment);
				},

				keywords = new HashSet<string>(new[] { "Script Templates", "Templates", "Comment", "Namespace", "ScriptTemplates" })
			};

			return provider;
		}
	}
}
