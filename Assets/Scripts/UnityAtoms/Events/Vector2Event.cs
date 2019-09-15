using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(Vector2Variable), menuName = Events + nameof(Vector2Variable), order = Order)]
    public sealed class Vector2Event : GameEvent<Vector2> { }
}
