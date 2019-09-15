using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(BoolVariable), menuName = Events + nameof(BoolVariable), order = Order)]
    public sealed class BoolEvent : GameEvent<bool> { }
}
