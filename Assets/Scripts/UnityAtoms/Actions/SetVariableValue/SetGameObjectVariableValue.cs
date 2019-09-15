using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(GameObjectVariable), menuName = SetVariable + nameof(GameObjectVariable), order = Order)]
    public sealed class SetGameObjectVariableValue : SetVariableValue<
        GameObject,
        GameObjectVariable,
        GameObjectReference,
        GameObjectEvent,
        GameObjectGameObjectEvent>
    { }
}
