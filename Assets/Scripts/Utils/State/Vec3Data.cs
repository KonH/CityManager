using System;
using UnityEngine;

namespace CityManager.Utils.State {
	[Serializable]
	public struct Vec3Data {
		public float X;
		public float Y;
		public float Z;

		public Vec3Data(Vector3 vector) {
			X = vector.x;
			Y = vector.y;
			Z = vector.z;
		}

		public Vector3 ToVector3() {
			return new Vector3(X, Y, Z);
		}
	}
}
