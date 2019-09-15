using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = "FloatFloat", menuName = Events + "FloatFloat", order = Order)]
    public sealed class FloatFloatEvent : GameEvent<float, float> { }
}
