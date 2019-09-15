using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(Vector3Variable), menuName = Events + nameof(Vector3Variable), order = Order)]
    public sealed class Vector3Event : GameEvent<Vector3> { }
}
