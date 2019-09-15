using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(StringVariable), menuName = SetVariable + nameof(StringVariable), order = Order)]
    public sealed class SetStringVariableValue : SetVariableValue<
        string,
        StringVariable,
        StringReference,
        StringEvent,
        StringStringEvent>
    { }
}
