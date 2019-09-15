using UnityEngine;

namespace Game
{
    public class SetActiveGameState : MonoBehaviour
    {
		public GameState activeOnState = default;
		private GameManager gameManager = default;

		private void Start()
		{
			gameManager = GameManager.Instance;
		}

		private void Update()
		{
			gameObject.SetActive(gameManager.gameState.Equals(activeOnState));
		}
	}
}