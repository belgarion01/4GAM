using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = "Change Scene", menuName = SceneManagement + "Change Scene", order = Order)]
    public sealed class ChangeScene : VoidAction
    {
        [FormerlySerializedAs("SceneName")]
        [SerializeField]
        private StringReference sceneName = default;

        public override void Do()
        {
            SceneManager.LoadScene(sceneName.Value);
        }
    }
}

