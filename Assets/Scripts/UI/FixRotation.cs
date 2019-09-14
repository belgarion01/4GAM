using UnityEngine;

namespace Game
{

	public class FixRotation : MonoBehaviour
	{
		Quaternion rotation = Quaternion.identity;

		private void Awake() => rotation = transform.rotation;

		private void LateUpdate() => transform.rotation = rotation;
	}

}