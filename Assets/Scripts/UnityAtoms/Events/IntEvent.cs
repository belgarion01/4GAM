using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(IntVariable), menuName = Events + nameof(IntVariable), order = Order)]
    public sealed class IntEvent : GameEvent<int> { }
}
