using UnityAtoms;
using UnityEngine;

namespace Game.HumanTower
{
	// Refacto : Should be separate into multiple "instantiate class" for differents purpose
	// reading would become easier
	public class Instantiate : AtomMonoBehaviour
	{
		[SerializeField] BoolReference m_isActive = default;
		[SerializeField] GameObject m_prefab = default;
		[SerializeField] Transform m_overrideSpawnPosition = default;
		[SerializeField] Vector3Reference m_spawnPosition = default;
		[SerializeField] QuaternionVariable m_spawnRotation = default;
		[SerializeField] UnityGameObjectEvent onInstantiate = default;

		private void Update()
		{
			if (m_overrideSpawnPosition == null) return;
			m_spawnPosition.ConstantValue = m_overrideSpawnPosition.position;
		}

		public void InstantiateInSelf(GameObject gameObject)
		{
			if (!m_isActive.Value) return;

			GameObject temp = 
				Instantiate(gameObject, transform);
			onInstantiate?.Invoke(temp);
		}

		public void InstantiateOutside(GameObject gameObject)
		{
			if (!m_isActive.Value) return;

			GameObject temp =
				Instantiate(gameObject);
			onInstantiate?.Invoke(temp);
		}

		public void InstantiateOutsidePosition(GameObject gameObject)
		{
			if (!m_isActive.Value) return;

			GameObject temp =
				Instantiate(gameObject, m_spawnPosition.Value, m_spawnRotation?.Value ?? Quaternion.identity);
			onInstantiate?.Invoke(temp);
		}

		public void InstantiateInSelfPosition(GameObject gameObject)
		{
			if (!m_isActive.Value) return;

			GameObject temp = 
				Instantiate(gameObject, m_spawnPosition.Value, m_spawnRotation?.Value ?? Quaternion.identity, transform);
			onInstantiate?.Invoke(temp);
		}

		public void InstantiateAtClosestPosition(Collider other)
		{
			if (!m_isActive.Value) return;
			if (other == null) return;
			GameObject temp =
				Instantiate(m_prefab, other.ClosestPoint(transform.position), m_spawnRotation?.Value ?? Quaternion.identity);
			onInstantiate?.Invoke(temp);
		}
	}
}