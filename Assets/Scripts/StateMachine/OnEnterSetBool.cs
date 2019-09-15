using UnityEngine;

namespace StateMachine
{
	public class OnEnterSetBool : StateMachineBehaviour
	{
		[AnimatorParameter(AnimatorControllerParameterType.Bool)]
		[SerializeField] private string parameterName = string.Empty;
		[SerializeField] private bool value = false;

		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
			=> animator?.SetBool(parameterName, value);
	}
}