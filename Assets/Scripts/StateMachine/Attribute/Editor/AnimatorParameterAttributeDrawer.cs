using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;
using System.Linq;

namespace StateMachine.Editor
{
	[CustomPropertyDrawer(typeof(AnimatorParameterAttribute))]
	public class AnimatorParameterAttributeDrawer : PropertyDrawer
	{
		readonly static GUIContent[] noAnimCont = new GUIContent[] { new GUIContent("Animator Controller not found") };
		readonly static GUIContent[] noContext = new GUIContent[] { new GUIContent("Context not found") };
		readonly static GUIContent[] noParameters = new GUIContent[] { new GUIContent("No parameters") };

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			var attribute = base.attribute as AnimatorParameterAttribute;

			if (property.propertyType != SerializedPropertyType.String)
			{
				EditorGUI.LabelField(position, label, "Property should be a string");
				return;
			}

			position.width -= EditorGUIUtility.singleLineHeight;
			EditorGUI.PropertyField(position, property);
			position.x += position.width;
			position.width = EditorGUIUtility.singleLineHeight;

			var animatorStateMachine = Selection.activeObject as AnimatorStateMachine;
			var context = AnimatorController.FindStateMachineBehaviourContext(animatorStateMachine.behaviours.FirstOrDefault());
			if (context == null)
			{
				EditorGUI.Popup(position, -1, noContext);
				return;
			}

			var controller = context.FirstOrDefault().animatorController;
			if (controller == null)
			{
				EditorGUI.Popup(position, -1, noAnimCont);
				return;
			}

			string[] paramaters = attribute.AllType ? 
				AnimatorParamaters.GetParameterNames(controller) :
				AnimatorParamaters.GetParameterNames(controller, attribute.ParamaterType);

			if (paramaters == null || paramaters.Length == 0)
			{
				EditorGUI.Popup(position, -1, noParameters);
				return;
			}
				
			int i;
			int length = paramaters.Length;
			for (i = 0; i < length; i++) { if (paramaters[i].Equals(property.stringValue)) break; }
			EditorGUI.BeginChangeCheck();
			i = EditorGUI.Popup(position, i, paramaters);
			if (EditorGUI.EndChangeCheck())
			{
				property.stringValue = paramaters[i];
				property.serializedObject.ApplyModifiedProperties();
			}
		}
	}
}