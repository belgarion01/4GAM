using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = "BoolBool", menuName = Events + "BoolBool", order = Order)]
    public sealed class BoolBoolEvent : GameEvent<bool, bool> { }
}
