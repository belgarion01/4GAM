// Copyright (c) - Ewan Argouse

using System;

namespace Game
{
	/// <summary>
	/// Allow to check change on update
	/// </summary>
	/// <typeparam name="T">Equatable type</typeparam>
	public struct ObserveUpdateChange<T>
	{
		public T lastValue { get; private set; }
		public Action<T> onChanged { get; private set; }

		/// <summary>
		/// Assign to event triggered on observe change
		/// </summary>
		/// <param name="m_current">Current value</param>
		public void Assign(Action<T> onChanged)
		{
			Assign(default, onChanged);
		}

		/// <summary>
		/// Assign to event triggered on observe change
		/// </summary>
		/// <param name="m_last">Last value</param>
		/// <param name="onChanged">Event to trigger</param>
		public void Assign(T m_last, Action<T> onChanged)
		{
			this.lastValue = m_last;
			this.onChanged = onChanged;
		}

		/// <summary>
		/// Observe if value has changed, and trigger it
		/// <para>Assign must be executed</para> 
		/// </summary>
		/// <param name="value">Value to observe</param>
		public void Observe(T value) => Observe(value, onChanged);

		/// <summary>
		/// Observe if value has changed, and trigger it
		/// </summary>
		/// <param name="value">Value to observe</param>
		/// <param name="onChanged">Triggered if changed</param>
		public void Observe(T value, Action onChanged) => Observe(value, onChanged);

		/// <summary>
		/// Observe if value has changed, and trigger it
		/// </summary>
		/// <param name="value">Value to observe</param>
		/// <param name="onChanged">Triggered if changed</param>
		public void Observe(T value, Action<T> onChanged)
		{
			if (value != null && !value.Equals(lastValue))
				onChanged?.Invoke(value);

			lastValue = value;
		}
	}
}