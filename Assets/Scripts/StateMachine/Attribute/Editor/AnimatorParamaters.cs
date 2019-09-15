using UnityEngine;
using UnityEditor.Animations;
using System.Collections.Generic;

namespace StateMachine.Editor
{
	public static class AnimatorParamaters
	{
		public static string[] GetParameterNames(Animator animator)
		{
			if (animator == null) return null;
			if (animator.runtimeAnimatorController == null) return null;

			AnimatorController controller = animator.runtimeAnimatorController as AnimatorController;
			string[] paramaterNames = GetParameterNames(controller);
			return paramaterNames;
		}

		public static string[] GetParameterNames(AnimatorController controller)
		{
			if (controller == null) return null;

			int length = controller.parameters.Length;
			string[] parameterNames = new string[length];
			for (int i = 0; i < length; i++)
			{
				parameterNames[i] = controller.parameters[i].name;
			}
			return parameterNames;
		}

		public static string[] GetParameterNames
			(AnimatorController controller, AnimatorControllerParameterType type)
		{
			if (controller == null) return null;

			int length = controller.parameters.Length;
			List<string> parameterNames = new List<string>();
			for (int i = 0; i < length; i++)
			{
				if (controller.parameters[i].type.Equals(type))
					parameterNames.Add(controller.parameters[i].name);
			}
			return parameterNames.ToArray();
		}
	}
}