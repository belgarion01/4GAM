using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(BoolVariable), menuName = Consts + nameof(BoolVariable), order = Order)]
    public sealed class BoolConstant : ScriptableObjectVariableBase<bool> { }
}
