using UnityEngine;

namespace Game
{

	public class HFTMovementController : MonoBehaviour
    {
		public new Rigidbody rigidbody = default;
		public HFTInput input = default;
		public float movementForce = 1f;
		public float rotationForce = 1f;

		Vector3 movement = Vector3.zero;
		bool canMove = true;

		public string InputHorizontalName => "Horizontal";
		public string InputVerticalName => "Vertical";

		private void Update()
		{
			HandleInput();

			Rotate();
		}

		private void FixedUpdate() => Move();

		private void HandleInput()
		{
			float horizontal = Input.GetAxisRaw(InputHorizontalName) + input.GetAxis(InputHorizontalName);
			float vertical = Input.GetAxisRaw(InputVerticalName) - input.GetAxis(InputVerticalName);
			movement = new Vector3(horizontal, 0f, vertical);
			if (movement.magnitude > 1) movement = movement.normalized;
		}

		private void Move()
		{
			if (!canMove) return;
			rigidbody.velocity = movement * movementForce + Physics.gravity;
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