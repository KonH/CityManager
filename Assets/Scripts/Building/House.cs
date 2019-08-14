using UnityEngine.Assertions;
using CityManager.Unit;
using CityManager.Utils;

namespace CityManager.Building {
	public sealed class House : InstancesHolder<House> {
		public BuildingSetup Setup;
		public int           Capacity;

		public bool HasFreePlaces {
			get {
				var occupiedPlaces = Setup.State.Data.Units.Count;
				return (occupiedPlaces < Capacity);
			}
		}

		void OnValidate() {
			Assert.IsNotNull(Setup);
			Assert.IsTrue(Capacity > 0);
		}

		public void AddUnit(UnitSetup unit) {
			var unitData  = unit.State.Data;
			var houseData = Setup.State.Data;

			unitData.HouseId = houseData.Id;
			houseData.Units.Add(unitData.Id);
		}
	}
}