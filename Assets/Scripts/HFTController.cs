using UnityEngine;

namespace Game
{
	public class HFTController : MonoBehaviour
	{
		public HFTGamepad gamepad = default;

		private void Awake() => gamepad.OnDisconnect += Remove;

		private void OnDestroy() => gamepad.OnDisconnect -= Remove;

		private void Remove() => Destroy(gameObject);
	}
}