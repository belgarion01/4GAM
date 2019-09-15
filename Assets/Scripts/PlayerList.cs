using System;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;

namespace Game
{
	public class PlayerList : MonoBehaviour
    {
		public List<GameObject> playerList = new List<GameObject>();
		public UnityGameObjectEvent onLastPlayer = default;
		public IntVariable outputPlayerCount = default;

		public static Action<int> onChange = default;

		private void Start()
		{
			onChange?.Invoke(playerList.Count);
		}

		public void Add(GameObject gameObject)
		{
			playerList?.Add(gameObject);
			onChange?.Invoke(playerList.Count);
			outputPlayerCount?.SetValue(playerList.Count);
		}

		public void Remove(GameObject gameObject)
		{
			playerList?.Remove(gameObject);
			onChange?.Invoke(playerList.Count);
			outputPlayerCount?.SetValue(playerList.Count);
			if (playerList.Count == 1)
			{
				onLastPlayer?.Invoke(gameObject);
			}
		}
	}
}