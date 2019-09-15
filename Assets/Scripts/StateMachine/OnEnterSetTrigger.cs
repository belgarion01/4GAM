using UnityEngine;

namespace StateMachine
{
	public class OnEnterSetTrigger : StateMachineBehaviour
	{
		[AnimatorParameter(AnimatorControllerParameterType.Trigger)]
		[SerializeField] private string parameterName = string.Empty;

		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
			=> animator?.SetTrigger(parameterName);
	}
}