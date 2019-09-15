using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(Vector3Variable), menuName = Consts + nameof(Vector3Variable), order = Order)]
    public sealed class Vector3Constant : ScriptableObjectVariableBase<Vector3> { }
}
