using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = "ColorColor", menuName = Events + "ColorColor", order = Order)]
    public sealed class ColorColorEvent : GameEvent<Color, Color> { }
}
