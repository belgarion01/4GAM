using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(Vector2Variable), menuName = Consts + nameof(Vector2Variable), order = Order)]
    public sealed class Vector2Constant : ScriptableObjectVariableBase<Vector2> { }
}
