using TMPro;
using UnityEngine;

namespace Game
{
    public class HFTColorSetter : MonoBehaviour
    {
		public TextMeshPro textMesh = default;
		public SkinnedMeshRenderer[] meshRenderers = default;
		public HFTGamepad gamepad = default;

		private static int playerNumber = 0;

		private void Awake()
		{
			SetColor(playerNumber++);
			SetName(gamepad.Name);

			gamepad.OnNameChange += ChangeName;
		}

		private void OnDestroy() => gamepad.OnNameChange -= ChangeName;

		void ChangeName(object sender, System.EventArgs e) => SetName(gamepad.Name);

		void SetName(string name) => textMesh?.SetText(name);

		void SetColor(int colorNdx)
		{
			float hue =
				(((colorNdx & 0x01) << 5) |
				((colorNdx & 0x02) << 3) |
				((colorNdx & 0x04) << 1) |
				((colorNdx & 0x08) >> 1) |
				((colorNdx & 0x10) >> 3) |
				((colorNdx & 0x20) >> 5)) / 64.0f;
			float val = (colorNdx & 0x20) != 0 ? 0.5f : 1.0f;
			float sat = (colorNdx & 0x10) != 0 ? 0.5f : 1.0f;

			Color playerColor = Color.HSVToRGB(hue, sat, val);

			gamepad.color = playerColor;
			textMesh.faceColor = playerColor;

			int length = meshRenderers.Length;
			for (int i = 0; i < length; i++)
			{
				meshRenderers[i].material.color = playerColor;
			}
		}
	}
}