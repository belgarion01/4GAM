using System;
using UnityEngine;

namespace StateMachine
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
	public class AnimatorParameterAttribute : PropertyAttribute
	{
		public bool AllType { get; } = false;
		public AnimatorControllerParameterType ParamaterType { get; } = default;

		public AnimatorParameterAttribute()
		{
			this.AllType = true;
		}

		public AnimatorParameterAttribute(AnimatorControllerParameterType animatorControllerParameterType)
		{
			this.ParamaterType = animatorControllerParameterType;
			this.AllType = false;
		}

	}
}
