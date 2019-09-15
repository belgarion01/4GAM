using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityAtoms
{
	public abstract class AtomMonoBehaviour : MonoBehaviour
	{
#if UNITY_EDITOR
		[SerializeField, HideInInspector] private string note = string.Empty;
        public Dictionary<UnityEngine.Object, Type> refs = new Dictionary<UnityEngine.Object, Type>();
#endif
    }
}
