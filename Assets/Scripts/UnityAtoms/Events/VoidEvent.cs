using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = "Void", menuName = Events + "Void", order = Order)]
    public sealed class VoidEvent : GameEvent<Void>
    {
        public void Raise()
        {
            Raise(new Void());
        }
    }
}
