using UnityEngine;

namespace Game
{
    public class Triggerable : MonoBehaviour
    {
		public LayerMask triggerMask = default;
		public UnityColliderEvent onTrigger = default;

		private void OnTriggerEnter(Collider other)
		{
			if (!triggerMask.Includes(other.gameObject.layer)) return;
			onTrigger?.Invoke(other);
		}
	}
}