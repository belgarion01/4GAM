using UnityEngine;

namespace Game
{
    public class Pusher : MonoBehaviour
    {
		public LayerMask triggerMask = default;
		public UnityColliderEvent onTrigger = default;

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


			Invulnerablity invulnerablity = other?.GetComponentInParent<Invulnerablity>();
			if (invulnerablity != null)
			{
				if (!invulnerablity.IsInvulnerable)
				{
					onTrigger?.Invoke(other);
				}
			}

			pushable?.Push(transform.position);
		}
	}
}