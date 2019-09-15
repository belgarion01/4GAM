using UnityEngine;

namespace StateMachine
{
	public class OnExitSetBool : StateMachineBehaviour
	{
		[AnimatorParameter(AnimatorControllerParameterType.Bool)]
		[SerializeField] string parameter = string.Empty;
		[SerializeField] bool value = false;

		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
			=> animator?.SetBool(parameter, value);
	}
}