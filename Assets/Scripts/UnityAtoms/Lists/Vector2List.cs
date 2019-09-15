using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(Vector2Variable), menuName = Lists + nameof(Vector2Variable), order = Order)]
    public sealed class Vector2List : ScriptableObjectList<Vector2, Vector2Event> { }
}
