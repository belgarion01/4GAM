using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(StringVariable), menuName = Lists + nameof(StringVariable), order = Order)]
    public sealed class StringList : ScriptableObjectList<string, StringEvent> { }
}
