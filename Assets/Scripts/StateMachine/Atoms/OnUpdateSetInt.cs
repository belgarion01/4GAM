using UnityAtoms;
using UnityEngine;

namespace StateMachine.Atoms
{
	public class OnUpdateSetInt : StateMachineBehaviour
	{
		[AnimatorParameter(AnimatorControllerParameterType.Float)]
		[SerializeField] string paramater = string.Empty;
		[SerializeField] IntVariable value = default;

		public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
			=> animator?.SetInteger(paramater, value?.Value ?? 0);
	}
}