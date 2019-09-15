using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class PlayerCountUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text textMesh = default;

		private void Awake() => PlayerList.onChange += UpdateUI;

		private void OnDestroy() => PlayerList.onChange -= UpdateUI;

		private void UpdateUI(int playerCount) => textMesh?.SetText(playerCount.ToString());
	}
}
