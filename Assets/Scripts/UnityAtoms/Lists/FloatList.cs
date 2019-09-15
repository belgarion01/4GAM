using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(FloatVariable), menuName = Lists + nameof(FloatVariable), order = Order)]
    public sealed class FloatList : ScriptableObjectList<float, FloatEvent> { }
}
