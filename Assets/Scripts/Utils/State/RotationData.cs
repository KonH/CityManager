using System;
using UnityEngine;

namespace CityManager.Utils.State {
	[Serializable]
	public struct RotationData {
		public float X;
		public float Y;
		public float Z;
		public float W;

		public RotationData(Quaternion rotation) {
			X = rotation.x;
			Y = rotation.y;
			Z = rotation.z;
			W = rotation.w;
		}

		public Quaternion ToQuaternion() {
			return new Quaternion(X, Y, Z, W);
		}
	}
}
