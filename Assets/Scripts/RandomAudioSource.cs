using UnityEngine;

namespace Game
{
    public class RandomAudioSource : MonoBehaviour
    {
		public AudioSource audioSource = default;
		public AudioClip[] audioClips = default;
		public bool onAwake = false;

		private void Awake()
		{
			if (onAwake)
				Randomize();
		}

		private void Randomize()
        {
			int random = Random.Range(0, audioClips.Length);
			audioSource.clip = audioClips[random];
        }
    }
}