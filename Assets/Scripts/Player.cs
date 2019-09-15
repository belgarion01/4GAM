using UnityEngine;

namespace Game
{
    public class Player : MonoBehaviour
    {
		private void Awake() => FindObjectOfType<PlayerList>()?.Add(gameObject);

		private void OnDestroy() => FindObjectOfType<PlayerList>()?.Remove(gameObject);
	}
}