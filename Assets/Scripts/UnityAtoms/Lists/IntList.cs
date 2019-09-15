using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(IntVariable), menuName = Lists + nameof(IntVariable), order = Order)]
    public sealed class IntList : ScriptableObjectList<int, IntEvent> { }
}
