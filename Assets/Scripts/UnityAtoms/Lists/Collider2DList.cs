using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = "Collider2D", menuName = Lists + "Collider2D", order = Order)]
    public sealed class Collider2DList : ScriptableObjectList<Collider2D, Collider2DEvent> { }
}
