using System;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class HFTPushController : MonoBehaviour
    {
		public HFTInput input = default;
		public UnityEvent onPressButton = default;
		public string InputPushButton => "fire1";

		public void Update()
		{
			HandleInput();
		}

		private void HandleInput()
		{
			bool pressed = input.GetButtonDown(InputPushButton);
			if (!pressed) return;
			onPressButton?.Invoke();
		}
	}
}