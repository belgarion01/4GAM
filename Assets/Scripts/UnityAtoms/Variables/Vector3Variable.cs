using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(Vector3Variable), menuName = Variables + nameof(Vector3Variable), order = Order)]
    public class Vector3Variable : EquatableScriptableObjectVariable<Vector3, Vector3Event, Vector3Vector3Event> { }
}
