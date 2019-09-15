using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(BoolVariable), menuName = SetVariable + nameof(BoolVariable), order = Order)]
    public sealed class SetBoolVariableValue : SetVariableValue<
        bool,
        BoolVariable,
        BoolReference,
        BoolEvent,
        BoolBoolEvent>
    { }
}
