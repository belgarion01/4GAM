using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = "Collider", menuName = Events + "Collider", order = Order)]
    public sealed class ColliderEvent : GameEvent<Collider> { }
}
