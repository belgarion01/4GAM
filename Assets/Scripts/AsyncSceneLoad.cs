using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class AsyncSceneLoad : MonoBehaviour
    {


		public void SceneLoad()
		{
			IEnumerator AsyncLoading()
			{
				SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
				yield return null;
			}

			StartCoroutine(AsyncLoading());
		}
	}
}