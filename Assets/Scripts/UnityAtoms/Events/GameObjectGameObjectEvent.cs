using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = "GameObjectGameObject", menuName = Events + "GameObjectGameObject", order = Order)]
    public sealed class GameObjectGameObjectEvent : GameEvent<GameObject, GameObject> { }
}
