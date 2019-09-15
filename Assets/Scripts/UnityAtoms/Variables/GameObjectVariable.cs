using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(GameObjectVariable), menuName = Variables + nameof(GameObjectVariable), order = Order)]
    public class GameObjectVariable : ScriptableObjectVariable<
        GameObject,
        GameObjectEvent,
        GameObjectGameObjectEvent>
    {
        protected override bool AreEqual(GameObject first, GameObject second)
        {
            return (first == null && second == null) || first != null && second != null && first.GetInstanceID() == second.GetInstanceID();
        }
    }
}
