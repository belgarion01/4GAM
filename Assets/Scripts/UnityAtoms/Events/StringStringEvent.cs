using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = "StringString", menuName = Events + "StringString", order = Order)]
    public sealed class StringStringEvent : GameEvent<string, string> { }
}
