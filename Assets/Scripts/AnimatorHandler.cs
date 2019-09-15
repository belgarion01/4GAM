using UnityEngine;

namespace Game
{
    public class AnimatorHandler : MonoBehaviour
    {
		public Animator animator = default;
		public string paramaterName = "";

		public void SetBool(bool value) => animator?.SetBool(paramaterName, value);
	}
}