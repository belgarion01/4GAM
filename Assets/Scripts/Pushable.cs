using UnityEngine;
using UnityEngine.Events;

namespace Game
{
	public class Pushable : MonoBehaviour
	{
		public new Rigidbody rigidbody = default;
		public float forceMultiplier = 1f;
		public ForceMode forceMode = ForceMode.Impulse;
		public UnityEvent onPush = default;

		bool canPush = true;

		public void Push(Vector3 pusher)
		{
			if (!canPush) return;
			onPush?.Invoke();
			Vector3 dir = (transform.position - pusher).normalized;
			rigidbody?.AddForce(dir * forceMultiplier, forceMode);
		}

		public void SetPushable(bool value) => canPush = value;
	}
}