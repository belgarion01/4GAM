using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(Vector3Variable), menuName = Lists + nameof(Vector3Variable), order = Order)]
    public sealed class Vector3List : ScriptableObjectList<Vector3, Vector3Event> { }
}
