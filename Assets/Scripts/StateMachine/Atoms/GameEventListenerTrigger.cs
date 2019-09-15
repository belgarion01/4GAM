using UnityAtoms;
using UnityEngine;

namespace StateMachine.Atoms
{
	public class GameEventListenerTrigger : StateMachineBehaviour, IGameEventListener<Void>
	{
		[Tooltip("Event to register with.")]
		[SerializeField] VoidEvent Event = default;

		[Tooltip("Triggered paramater")]
		[AnimatorParameter(AnimatorControllerParameterType.Trigger)]
		[SerializeField] string paramater = string.Empty;

		private Animator animator = default;

		private void OnEnable() => Event?.RegisterListener(this);

		private void OnDisable() => Event?.UnregisterListener(this);

		override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
			=> this.animator = animator;

		public void OnEventRaised(Void @void) => animator?.SetTrigger(paramater);
	}
}