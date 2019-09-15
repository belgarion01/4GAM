using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(FloatVariable), menuName = Variables + nameof(FloatVariable), order = Order)]
    public class FloatVariable : EquatableScriptableObjectVariable<float, FloatEvent, FloatFloatEvent>, IWithApplyChange<float, FloatEvent, FloatFloatEvent>
    {
        public void ApplyChange(float amount) => SetValue(Value + amount);

        public void ApplyChange(FloatVariable amount)
            => SetValue(Value + amount.Value);
    }
}
