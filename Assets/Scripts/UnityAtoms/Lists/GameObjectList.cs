using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(GameObjectVariable), menuName = Lists + nameof(GameObjectVariable), order = Order)]
    public sealed class GameObjectList : ScriptableObjectList<GameObject, GameObjectEvent> { }
}
