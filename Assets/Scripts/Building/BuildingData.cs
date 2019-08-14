using System;
using System.Collections.Generic;
using CityManager.Utils.State;

namespace CityManager.Building {
	[Serializable]
	public sealed class BuildingData {
		public string                  Category;
		public string                  Name;
		public int                     Id;
		public Vec3Data                Position;
		public RotationData            Rotation;
		public List<int>               Units     = new List<int>();
		public Dictionary<string, int> Resources = new Dictionary<string, int>();
	}
}