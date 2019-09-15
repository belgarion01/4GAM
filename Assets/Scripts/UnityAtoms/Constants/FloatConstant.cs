using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(FloatVariable), menuName = Consts + nameof(FloatVariable), order = Order)]
    public sealed class FloatConstant : ScriptableObjectVariableBase<float> { }
}
