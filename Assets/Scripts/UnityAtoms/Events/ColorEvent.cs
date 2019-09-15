using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(ColorVariable), menuName = Events + nameof(ColorVariable), order = Order)]
    public sealed class ColorEvent : GameEvent<Color> { }
}
