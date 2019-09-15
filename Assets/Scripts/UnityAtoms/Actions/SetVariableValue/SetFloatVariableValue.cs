using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(FloatVariable), menuName = SetVariable + nameof(FloatVariable), order = Order)]
    public sealed class SetFloatVariableValue : SetVariableValue<
        float,
        FloatVariable,
        FloatReference,
        FloatEvent,
        FloatFloatEvent>
    { }
}
