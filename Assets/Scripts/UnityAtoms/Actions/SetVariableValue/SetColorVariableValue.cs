using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(ColorVariable), menuName = SetVariable + nameof(ColorVariable), order = Order)]
    public sealed class SetColorVariableValue : SetVariableValue<
        Color,
        ColorVariable,
        ColorReference,
        ColorEvent,
        ColorColorEvent>
    { }
}
