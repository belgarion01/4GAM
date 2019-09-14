using System;
using UnityEngine;

namespace Game
{
	[RequireComponent(typeof(Rigidbody), typeof(HFTInput), typeof(HFTGamepad))]
    public class HFTController : MonoBehaviour
    {
		public new Rigidbody rigidbody = default;
		public HFTInput input = default;
		public HFTGamepad gamepad = default;
		public float movementForce = 1f;
		public float rotationForce = 1f;

		Vector3 movement = Vector3.zero;
		bool canMove = true;

		public string InputHorizontalName => "Horizontal";
		public string InputVerticalName => "Vertical";

		private void Awake() => gamepad.OnDisconnect += Remove;

		private void Remove() => Destroy(gameObject);

		private void Update()
		{
			HandleInput();

			Rotate();
		}

		private void HandleInput()
		{
			float horizontal = Input.GetAxis(InputHorizontalName) + input.GetAxis(InputHorizontalName);
			float vertical = Input.GetAxis(InputVerticalName) + input.GetAxis(InputVerticalName);
			movement = new Vector3(horizontal, 0f, vertical);
			if (movement.magnitude > 1) movement = movement.normalized;
		}

		private void Move()
		{
			if (!canMove) return;
			rigidbody.velocity = movement * movementForce;
		}

		private void Rotate()
		{
			if (!canMove) return;
			if (movement == Vector3.zero) return;

			transform.rotation = Quaternion.Slerp
			(
				transform.rotation,
				Quaternion.LookRotation(movement),
				rotationForce * Time.deltaTime
			);
		}

		private void FixedUpdate() => Move();

		public void SetMovement(bool value) => canMove = value;
	}
}