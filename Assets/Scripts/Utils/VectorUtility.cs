using UnityEngine;

namespace Game
{
	public static class VectorUtility
	{
		public static Vector3 WithY(this Vector3 v, float y)
		{
			return new Vector3(v.x, y, v.z);
		}

		public static Vector2[] ToVector2ArrayKeepZ(this Vector3[] v3)
		{
			return System.Array.ConvertAll<Vector3, Vector2>(v3, GetV3ZfromV2);
		}

		public static Vector3 ToVector3YToZ(this Vector2 v)
		{
			return new Vector3(v.x, 0f, v.y);
		}

		public static Vector2 GetV3YfromV2(Vector3 v3)
		{
			return new Vector2(v3.x, v3.y);
		}

		public static Vector2 GetV3ZfromV2(Vector3 v3)
		{
			return new Vector2(v3.x, v3.z);
		}

		public static Vector2 ZToVector2(this Vector3 vector3)
		{
			return new Vector2(vector3.x, vector3.z);
		}

		public static Vector3 GetTransformDirection(this Transform transform, Vector3Direction vector3Direction)
		{
			switch (vector3Direction)
			{
				case Vector3Direction.Up:
					return transform.up;
				case Vector3Direction.Down:
					return -transform.up;
				case Vector3Direction.Right:
					return transform.right;
				case Vector3Direction.Left:
					return -transform.right;
				case Vector3Direction.Foward:
					return transform.forward;
				case Vector3Direction.Back:
					return -transform.forward;
				default:
					return Vector3.zero;
			}
		}

		public static Vector3 GetDirection(Vector3Direction vector3Direction)
		{
			switch (vector3Direction)
			{
				case Vector3Direction.Up:
					return Vector3.up;
				case Vector3Direction.Down:
					return Vector3.down;
				case Vector3Direction.Right:
					return Vector3.right;
				case Vector3Direction.Left:
					return Vector3.left;
				case Vector3Direction.Foward:
					return Vector3.forward;
				case Vector3Direction.Back:
					return Vector3.back;
				default:
					return Vector3.zero;
			}
		}
	}
}