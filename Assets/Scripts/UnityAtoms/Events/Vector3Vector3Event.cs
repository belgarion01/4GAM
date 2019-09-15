using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = "Vector3Vector3", menuName = Events + "Vector3Vector3", order = Order)]
    public sealed class Vector3Vector3Event : GameEvent<Vector3, Vector3> { }
}
