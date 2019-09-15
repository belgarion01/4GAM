using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(ColorVariable), menuName = Variables + nameof(ColorVariable), order = Order)]
    public class ColorVariable : EquatableScriptableObjectVariable<Color, ColorEvent, ColorColorEvent> { }
}
