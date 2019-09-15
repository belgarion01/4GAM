using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(StringVariable), menuName = Events + nameof(StringVariable), order = Order)]
    public sealed class StringEvent : GameEvent<string> { }
}
