using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(QuaternionVariable), menuName = Variables + nameof(QuaternionVariable), order = Order)]
    public class QuaternionVariable : ScriptableObjectVariable<Quaternion, QuaternionEvent, QuaternionQuaternionEvent>
    {
        protected override bool AreEqual(Quaternion first, Quaternion second)
        {
            return first.Equals(second);
        }
    }
}
