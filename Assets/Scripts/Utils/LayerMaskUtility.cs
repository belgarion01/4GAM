using UnityEngine;

namespace Game
{
	public static class LayerMaskUtility
	{
		public static bool Includes(this LayerMask mask, int layer)
		{
			return (mask.value & 1 << layer) > 0;
		}
	}
}