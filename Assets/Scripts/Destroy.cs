using UnityEngine;

namespace Game.HumanTower
{
	public class Destroy : MonoBehaviour
	{
		public void DestroyThisIfFalse(bool value)
		{
			if (value) return;
			Destroy(gameObject);
		}

		public void DestroyThis()
		{
			Destroy(gameObject);
		}

		public void DestroyThis(Transform transform)
		{
			Destroy(transform.gameObject);
		}

		public void DestroyThis(Component component)
		{
			Destroy(component);
		}

		public void DestroyOtherGameObject(Collider other)
		{
			Destroy(other.gameObject);
		}
	}
}