using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(GameObjectVariable), menuName = Events + nameof(GameObjectVariable), order = Order)]
    public sealed class GameObjectEvent : GameEvent<GameObject> { }
}
