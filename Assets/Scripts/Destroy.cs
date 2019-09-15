using UnityEngine;
using UnityEngine.Events;

namespace Game.HumanTower
{
	public class Destroy : MonoBehaviour
	{
		public UnityEvent onDestroy = default;

		public void DestroyThisIfFalse(bool value)
		{
			if (value) return;
			Destroy(gameObject);
			onDestroy?.Invoke();
		}

		public void DestroyThis()
		{
			Destroy(gameObject);
			onDestroy?.Invoke();
		}

		public void DestroyThis(Transform transform)
		{
			Destroy(transform.gameObject);
			onDestroy?.Invoke();
		}

		public void DestroyThis(Component component)
		{
			Destroy(component);
			onDestroy?.Invoke();
		}

		public void DestroyOtherGameObject(Collider other)
		{
			Destroy(other.transform.root.gameObject);
			onDestroy?.Invoke();
		}
	}
}