using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = "Collider2D", menuName = Events + "Collider2D", order = Order)]
    public sealed class Collider2DEvent : GameEvent<Collider2D> { }
}
