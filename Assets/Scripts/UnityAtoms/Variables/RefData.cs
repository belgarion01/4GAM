using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityAtoms
{
	public class RefData : ScriptableObject
	{
#if UNITY_EDITOR
		public Dictionary<UnityEngine.Object, Type> refs = new Dictionary<UnityEngine.Object, Type>();
#endif
	}
}
