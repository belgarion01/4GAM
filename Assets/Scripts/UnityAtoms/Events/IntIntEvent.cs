using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = "IntInt", menuName = Events + "IntInt", order = Order)]
    public sealed class IntIntEvent : GameEvent<int, int> { }
}
