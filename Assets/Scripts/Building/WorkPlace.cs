using UnityEngine.Assertions;
using CityManager.Unit;
using CityManager.Utils;

namespace CityManager.Building {
	public class WorkPlace : InstancesHolder<WorkPlace> {
		public BuildingSetup Setup;
		public int           Capacity;

		public bool HasFreeSpace => Setup.State.Data.Units.Count < Capacity;
		
		void OnValidate() {
			Assert.IsNotNull(Setup);
			Assert.IsTrue(Capacity > 0);
		}

		void Update() {
			if ( !HasFreeSpace ) {
				return;
			}
			var unit = UnitState.TryGetNonWorkingUnit();
			if ( !unit ) {
				return;
			}
			
			var unitData  = unit.State.Data;
			var placeData = Setup.State.Data;
			
			unitData.WorkPlaceId = placeData.Id;
			placeData.Units.Add(unitData.Id);
		}
	}
}