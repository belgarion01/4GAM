using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(FloatVariable), menuName = Events + nameof(FloatVariable), order = Order)]
    public sealed class FloatEvent : GameEvent<float> { }
}
