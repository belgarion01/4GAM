using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(BoolVariable), menuName = Lists + nameof(BoolVariable), order = Order)]
    public sealed class BoolList : ScriptableObjectList<bool, BoolEvent> { }
}
