using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(ColorVariable), menuName = Consts + nameof(ColorVariable), order = Order)]
    public sealed class ColorConstant : ScriptableObjectVariableBase<Color> { }
}
