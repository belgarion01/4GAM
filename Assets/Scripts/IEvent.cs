using UnityEngine.Events;

namespace Game
{
	public interface IEvent
	{
		UnityEvent OnUnityEvent { get; }
	}

	public interface IEvent<T>
	{
		UnityEvent<T> OnUnityEvent { get; }
	}
}