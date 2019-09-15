using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = "Vector2Vector2", menuName = Events + "Vector2Vector2", order = Order)]
    public sealed class Vector2Vector2Event : GameEvent<Vector2, Vector2> { }
}
