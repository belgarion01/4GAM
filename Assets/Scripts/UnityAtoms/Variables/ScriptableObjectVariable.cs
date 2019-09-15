using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityAtoms
{
    public abstract partial class ScriptableObjectVariable<T, E1, E2> : ScriptableObjectVariableBase<T>,
        ISerializationCallbackReceiver, IVariableIcon
        where E1 : GameEvent<T>
        where E2 : GameEvent<T, T>
    {
        public override T Value { get { return GetValue(); } set { SetValue(value); } }

        [SerializeField]
        private T initialValue = default;
        public T InitialValue => initialValue;

        [SerializeField]
        private bool resetOnLoadScene = false;

        [SerializeField]
        private T previousValue = default;
        public T PreviousValue => previousValue;

        public E1 Changed = default;

        public E2 ChangedWithHistory = default;

        protected abstract bool AreEqual(T first, T second);

        private void OnEnable()
        {
            SceneManager.sceneLoaded += ResetValue;
            Changed?.Raise(Value);
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= ResetValue;
        }

        public virtual void SetValue(T newValue)
        {
            if (!AreEqual(value, newValue))
            {
                previousValue = value;
                value = newValue;
                Changed?.Raise(value);
                ChangedWithHistory?.Raise(value, previousValue);
            }
        }

        public virtual void SetValue(ScriptableObjectVariable<T, E1, E2> variable)
        {
            SetValue(variable.Value);
        }

        public void OnBeforeSerialize() { }
        public void OnAfterDeserialize() { value = initialValue; }

        public void ResetValue()
        {
            SetValue(initialValue);
        }

        #region Observable
        public IObservable<T> ObserveChange()
        {
            if (Changed == null)
            {
                throw new Exception("You must assign a Changed event in order to observe variable changes.");
            }

            return new ObservableEvent<T>(Changed.Register, Changed.Unregister);
        }

        public IObservable<ValueTuple<T, T>> ObserveChangeWithHistory()
        {
            if (ChangedWithHistory == null)
            {
                throw new Exception("You must assign a ChangedWithHistory event in order to observe variable changes.");
            }

            return new ObservableEvent<T, T, ValueTuple<T, T>>(
                register: ChangedWithHistory.Register,
                unregister: ChangedWithHistory.Unregister,
                createCombinedModel: (n, o) => new ValueTuple<T, T>(n, o)
            );
        }
        #endregion // Observable

        private void ResetValue(Scene scene, LoadSceneMode mode)
        {
            if (resetOnLoadScene)
            {
                ResetValue();
            }
        }

        static partial void DoStuffOnUpdate(ScriptableObjectVariable<T, E1, E2> self);
    }
}
