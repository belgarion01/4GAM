using System;
using UnityEngine;

namespace Game
{
	public class HFTMovementController : MonoBehaviour
    {
		public new Rigidbody rigidbody = default;
		public HFTInput input = default;
		public float movementForce = 1f;
		public float rotationForce = 1f;

		public UnityBoolEvent onMove = default;

		Vector3 movement = Vector3.zero;
		bool canMove = true;

		ObserveUpdateChange<bool> observeMovement = default;
		Action<bool> onMoveChanged = default;

		public string InputHorizontalName => "Horizontal";
		public string InputVerticalName => "Vertical";

		private void Awake()
		{
			observeMovement.Assign(onMoveChanged);
			onMoveChanged += OnMoveChanged;
		}

		private void OnDestroy()
		{
			onMoveChanged -= OnMoveChanged;
		}

		private void OnMoveChanged(bool isMoving) => onMove?.Invoke(isMoving);

		private void Update()
		{
			//observeMovement.Observe(movement.magnitude > 0f);
			onMove?.Invoke(movement.magnitude > 0f);

			HandleInput();

			Rotate();
		}

		private void FixedUpdate() => Move();

		private void HandleInput()
		{
			float horizontal = input.GetAxis(InputHorizontalName);
			float vertical =  - input.GetAxis(InputVerticalName);
			movement = new Vector3(horizontal, 0f, vertical);
			if (movement.magnitude > 1) movement = movement.normalized;
		}

		private void Move()
		{
			if (!canMove) return;
			rigidbody.velocity = movement * movementForce + /*Physics.gravity*/new Vector3(0f, -3f, 0f);
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

		public void SetMovement(bool value) => canMove = value;
	}
}