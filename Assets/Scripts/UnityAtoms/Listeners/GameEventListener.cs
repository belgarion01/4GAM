using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace UnityAtoms
{
    public abstract class GameEventListener<T, GA, E, UER> : AtomMonoBehaviour, IGameEventListener<T>, IListenerIcon
        where GA : GameAction<T>
        where E : GameEvent<T> where UER : UnityEvent<T>
    {
        [FormerlySerializedAs("Event")]
        [SerializeField]
        private E @event = null;

        public E GameEvent { get { return @event; } set { @event = value; } }

        [FormerlySerializedAs("UnityEventResponse")]
        [SerializeField]
        private UER unityEventResponse = null;

        [FormerlySerializedAs("GameActionResponses")]
        [SerializeField]
        private List<GA> gameActionResponses = new List<GA>();

        private void OnEnable()
        {
            if (GameEvent == null) return;
            GameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            if (GameEvent == null) return;
            GameEvent.UnregisterListener(this);
        }

        public void OnEventRaised(T item)
        {
            if (unityEventResponse != null) { unityEventResponse.Invoke(item); }
            for (int i = 0; gameActionResponses != null && i < gameActionResponses.Count; ++i)
            {
                gameActionResponses[i].Do(item);
            }
        }
    }

    public abstract class GameEventListener<T1, T2, GA, E, UER> : MonoBehaviour, IGameEventListener<T1, T2>, IListenerIcon
        where GA : GameAction<T1, T2>
        where E : GameEvent<T1, T2>
        where UER : UnityEvent<T1, T2>
    {
        [FormerlySerializedAs("Event")]
        [SerializeField]
        private E @event = default;

        public E GameEvent { get { return @event; } set { @event = value; } }

        [FormerlySerializedAs("UnityEventResponse")]
        [SerializeField]
        private UER unityEventResponse = default;

        [FormerlySerializedAs("GameActionResponses")]
        [SerializeField]
        private List<GA> gameActionResponses = new List<GA>();

        private void OnEnable()
        {
            if (@event == null) return;
            GameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            if (@event == null) return;
            GameEvent.UnregisterListener(this);
        }

        public void OnEventRaised(T1 first, T2 second)
        {
            if (unityEventResponse != null) { unityEventResponse.Invoke(first, second); }
            for (int i = 0; gameActionResponses != null && i < gameActionResponses.Count; ++i)
            {
                gameActionResponses[i].Do(first, second);
            }
        }
    }
}
