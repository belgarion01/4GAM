using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(Vector2Variable), menuName = Variables + nameof(Vector2Variable), order = Order)]
    public class Vector2Variable : EquatableScriptableObjectVariable<Vector2, Vector2Event, Vector2Vector2Event> { }
}
