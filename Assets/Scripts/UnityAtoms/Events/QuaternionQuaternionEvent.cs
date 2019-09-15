using UnityEngine;

namespace UnityAtoms
{
    using static AtomMenu;
    [CreateAssetMenu(fileName = "QuaternionQuaternion", menuName = Events + "QuaternionQuaternion", order = Order)]
    public class QuaternionQuaternionEvent : GameEvent<Quaternion, Quaternion> { }
}
