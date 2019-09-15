using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(StringVariable), menuName = Variables + nameof(StringVariable), order = Order)]
    public class StringVariable : EquatableScriptableObjectVariable<
        string,
        StringEvent,
        StringStringEvent>
    { }
}
