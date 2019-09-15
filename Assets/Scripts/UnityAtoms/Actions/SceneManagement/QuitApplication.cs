using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = "Quit Application", menuName = SceneManagement + "Quit Application", order = Order)]
    public sealed class QuitApplication : VoidAction
    {
        public override void Do()
        {
            Application.Quit();
        }
    }
}

