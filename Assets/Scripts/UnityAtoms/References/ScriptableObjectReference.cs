namespace UnityAtoms
{
    public abstract class ScriptableObjectReference{}

    public abstract class ScriptableObjectReference<T, V> : ScriptableObjectReference
        where V : ScriptableObjectVariableBase<T>
    {
        public bool UseConstant;

        public T ConstantValue;

        public V Variable;

        protected ScriptableObjectReference()
        {
            UseConstant = true;
        }

        protected ScriptableObjectReference(T value) : this()
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public T Value
        {
            get
            {
                if(UseConstant)
                {
                    return ConstantValue;
                }
                else
                {
                    if(Variable == null)
                    {
                        return default;
                    }
                    return Variable.Value;
                }
            }
        }

        public static implicit operator T(ScriptableObjectReference<T, V> reference)
        {
            return reference.Value;
        }
    }
}
