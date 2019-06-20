using System.Collections.Generic;
using CityManager.Unit;
using CityManager.Building;

namespace CityManager {
	public class StateData {
		public CommonUnitData     UnitData     = new CommonUnitData();
		public List<UnitData>     Units        = new List<UnitData>();
		public CommonBuildingData BuildingData = new CommonBuildingData();
		public List<BuildingData> Buildings    = new List<BuildingData>();
	}
}