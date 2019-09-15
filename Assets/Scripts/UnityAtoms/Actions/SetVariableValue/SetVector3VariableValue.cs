using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(Vector3Variable), menuName = SetVariable + nameof(Vector3Variable), order = Order)]
    public sealed class SetVector3VariableValue : SetVariableValue<
        Vector3,
        Vector3Variable,
        Vector3Reference,
        Vector3Event,
        Vector3Vector3Event>
    { }
}
