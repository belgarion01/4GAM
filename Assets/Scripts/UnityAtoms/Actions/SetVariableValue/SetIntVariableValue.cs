using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(IntVariable), menuName = SetVariable + nameof(IntVariable), order = Order)]
    public sealed class SetIntVariableValue : SetVariableValue<
        int,
        IntVariable,
        IntReference,
        IntEvent,
        IntIntEvent>
    { }
}
