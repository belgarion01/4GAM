using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(StringVariable), menuName = Consts + nameof(StringVariable), order = Order)]
    public sealed class StringConstant : ScriptableObjectVariableBase<string> { }
}
