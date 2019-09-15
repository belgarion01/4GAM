using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class AsyncSceneLoad : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.L)) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void SceneLoad()
		{
            /*
			IEnumerator AsyncLoading()
			{
				SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
				yield return null;
			}

			StartCoroutine(AsyncLoading());
            */
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}
}