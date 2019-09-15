using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(ColorVariable), menuName = Lists + nameof(ColorVariable), order = Order)]
    public sealed class ColorList : ScriptableObjectList<Color, ColorEvent> { }
}
