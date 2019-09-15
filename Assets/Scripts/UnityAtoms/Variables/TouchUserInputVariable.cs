using UnityEngine;

namespace UnityAtoms.Mobile
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = "TouchUserInput", menuName = Variables + "TouchUserInput", order = Order)]
    public sealed class TouchUserInputVariable : EquatableScriptableObjectVariable<
        TouchUserInput,
        TouchUserInputGameEvent,
        TouchUserInputTouchUserInputGameEvent>
    { }

}
