using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(BoolVariable), menuName = Variables + nameof(BoolVariable), order = Order)]
    public class BoolVariable : EquatableScriptableObjectVariable<bool, BoolEvent, BoolBoolEvent> { }
}
