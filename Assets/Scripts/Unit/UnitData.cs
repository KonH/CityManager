using System;
using CityManager.Utils.State;

namespace CityManager.Unit {
	[Serializable]
	public class UnitData {
		public int          Id;
		public int          HouseId;
		public int          WorkPlaceId;
		public Vec3Data     Position;
		public RotationData Rotation;
		public string       CurrentState;
	}
}