using System;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
	[Serializable]
	public class UnityTransformEvent : UnityEvent<Transform> { }
}