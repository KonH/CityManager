using System;
using System.Collections.Generic;
using CityManager.Utils.State;

namespace CityManager.Building {
	[Serializable]
	public class BuildingData {
		public string       Category;
		public string       Name;
		public int          Id;
		public Vec3Data     Position;
		public RotationData Rotation;
		public List<int>    Units;
	}
}