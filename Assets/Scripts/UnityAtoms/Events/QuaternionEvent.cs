using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = nameof(QuaternionVariable), menuName = Events + nameof(QuaternionVariable), order = Order)]
    public class QuaternionEvent : GameEvent<Quaternion> { }
}
