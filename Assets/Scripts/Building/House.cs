using UnityEngine.Assertions;
using CityManager.Utils;

namespace CityManager.Building {
	public class House : InstancesHolder<House> {
		public int           Capacity;
		public BuildingState State;

		void OnValidate() {
			Assert.IsTrue(Capacity > 0);
			Assert.IsNotNull(State);
		}
	}
}