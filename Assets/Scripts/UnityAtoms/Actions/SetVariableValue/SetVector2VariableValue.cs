using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(Vector2Variable), menuName = SetVariable + nameof(Vector2Variable), order = Order)]
    public sealed class SetVector2VariableValue : SetVariableValue<
        Vector2,
        Vector2Variable,
        Vector2Reference,
        Vector2Event,
        Vector2Vector2Event>
    { }
}
