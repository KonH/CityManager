using System;
using CityManager.Utils.State;

namespace CityManager.Unit {
	[Serializable]
	public sealed class UnitData {
		public int          Id;
		public int          HouseId;
		public int          WorkPlaceId;
		public Vec3Data     Position;
		public RotationData Rotation;
		public string       CurrentState;
		public float        StateProgress;
		public string       Inventory;
	}
}