using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(IntVariable), menuName = Consts + nameof(IntVariable), order = Order)]
    public sealed class IntConstant : ScriptableObjectVariableBase<int> { }
}
