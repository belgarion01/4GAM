using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class Delay : MonoBehaviour
    {
		public float seconds = 1f;
		public UnityEvent onFinish = default;

        public void Launch()
		{
			IEnumerator Delay()
			{
				WaitForSeconds waitForSeconds = new WaitForSeconds(seconds);
				yield return waitForSeconds;
				onFinish?.Invoke();
				yield return null;
			}

			StartCoroutine(Delay());
		}
    }
}