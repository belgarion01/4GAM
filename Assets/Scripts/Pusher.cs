using UnityEngine;

namespace Game
{
    public class Pusher : MonoBehaviour
    {
		public LayerMask triggerMask = default;

		Pushable self = default;

		private void Awake()
		{
			self = gameObject.GetComponentInParent<Pushable>();
		}

		private void OnTriggerEnter(Collider other)
		{
			Pushable pushable = other?.GetComponentInParent<Pushable>();
			if (self != null)
				if (self.GetInstanceID().Equals(pushable.GetInstanceID())) return;
			if (!triggerMask.Includes(other.gameObject.layer)) return;
			pushable?.Push(transform.position);
		}
	}
}