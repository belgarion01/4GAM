using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(IntVariable), menuName = Variables + nameof(IntVariable), order = Order)]
    public class IntVariable : EquatableScriptableObjectVariable<int, IntEvent, IntIntEvent>, IWithApplyChange<int, IntEvent, IntIntEvent>
    {
        public void ApplyChange(int amount)
        {
            SetValue(Value + amount);
        }

        public void ApplyChange(EquatableScriptableObjectVariable<int, IntEvent, IntIntEvent> amount)
        {
            SetValue(Value + amount.Value);
        }
    }
}
