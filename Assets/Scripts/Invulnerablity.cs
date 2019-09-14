//Copyright (c) Ewan Argouse - http://narudgi.github.io/

using UnityEngine;
using UnityEngine.Events;

namespace Game
{
	public class Invulnerablity : MonoBehaviour
	{
		public bool IsInvulnerable { get; private set; } = false;

		public UnityEvent OnBecomeInvulnerable = default;
		public UnityEvent OnFinishInvulnerable = default;

		[SerializeField] private float invulnerableTime = 2f;

		private float timer = 0f;

		private void Update() => HandleInvulnerableTimer();

		private void HandleInvulnerableTimer()
		{
			if (timer.Equals(Mathf.Infinity)) return;
			if (!IsInvulnerable) return;
			if (timer <= 0f)
			{
				if (IsInvulnerable)
					OnFinishInvulnerable?.Invoke();

				IsInvulnerable = false;
				return;
			}

			timer -= Time.deltaTime;
		}

		public void SetInvulnerable()
		{
			if (invulnerableTime <= 0f) return;

			timer = invulnerableTime;
			OnBecomeInvulnerable?.Invoke();
			IsInvulnerable = true;
		}
	}
}