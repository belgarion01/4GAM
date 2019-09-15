using UnityEngine;
using UnityEngine.Events;

namespace Game
{
	public class GameManager : MonoBehaviour
    {
		public GameState gameState = GameState.Lobby;

		public static GameManager Instance { get; private set; } = default;

		public UnityEvent onStartLobby = default;
		public UnityEvent onLaunchGame = default;
		public UnityEvent onFinshGame = default;

		private void Awake()
        {
			ChangeState(GameState.Lobby);

			if (Instance == null)
				Instance = this;
			else
				Destroy(this.gameObject);
		}

		public void LaunchGame()
		{
			ChangeState(GameState.InGame);
		}

		public void FinishGame()
		{
			ChangeState(GameState.Finish);
		}

		private void ChangeState(GameState newState)
		{
			gameState = newState;

			switch (gameState)
			{
				case GameState.Lobby:
					onStartLobby?.Invoke();
					break;
				case GameState.InGame:
					onLaunchGame?.Invoke();
					break;
				case GameState.Finish:
					onFinshGame?.Invoke();
					break;
			}
		}
    }
}