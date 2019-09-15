using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace UnityAtoms
{
    public abstract class ScriptableObjectVariableBase<T> : RefData, IConstantIcon
    {
        public virtual T Value { get { return GetValue(); } set { throw new NotImplementedException(); } }

        [Multiline]
        public string DeveloperDescription = "";

        [FormerlySerializedAs("value")]
        [SerializeField]
        protected T value;

        protected virtual T GetValue()
        {
            return value;
        }

        protected bool Equals(ScriptableObjectVariableBase<T> other)
        {
            return EqualityComparer<T>.Default.Equals(value, other.value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ScriptableObjectVariableBase<T>)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return EqualityComparer<T>.Default.GetHashCode(value);
            }
        }

        public static bool operator ==(ScriptableObjectVariableBase<T> left, ScriptableObjectVariableBase<T> right) { return Equals(left, right); }
        public static bool operator !=(ScriptableObjectVariableBase<T> left, ScriptableObjectVariableBase<T> right) { return !Equals(left, right); }
    }
}
