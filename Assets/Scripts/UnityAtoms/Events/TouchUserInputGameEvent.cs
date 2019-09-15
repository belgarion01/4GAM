using UnityEngine;

namespace UnityAtoms.Mobile
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = "TouchUserInput", menuName = Events + "TouchUserInput", order = Order)]
    public sealed class TouchUserInputGameEvent : GameEvent<TouchUserInput> { }
}
