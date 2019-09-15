using UnityAtoms;
using UnityEngine;

namespace StateMachine.Atoms
{
	public class OnUpdateSetFloat : StateMachineBehaviour
	{
		[AnimatorParameter(AnimatorControllerParameterType.Float)]
		[SerializeField] string paramater = string.Empty;
		[SerializeField] FloatVariable value = default;

		public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
			=> animator?.SetFloat(paramater, value?.Value ?? 0f);
	}
}