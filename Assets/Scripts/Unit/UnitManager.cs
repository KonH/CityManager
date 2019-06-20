using UnityEngine;
using Zenject;
using CityManager.Building;

namespace CityManager.Unit {
	public class UnitManager : IInitializable {
		UnitSetup.Factory _factory;
		StateManager      _stateManager;
		
		public UnitManager(UnitSetup.Factory factory, StateManager stateManager) {
			_factory      = factory;
			_stateManager = stateManager;
		}
		
		public void Initialize() {
			var saveData = _stateManager.SaveData;
			foreach ( var unit in saveData.Units ) {
				Prespawn(unit);
			}
		}

		public UnitSetup Spawn() {
			var instance = SpawnPrefab();
			AssignNewId(instance.State);
			return instance;
		}

		public void AssignToHouse(UnitSetup unit, House house) {
			var unitState  = unit.State.Instance;
			var houseState = house.State.Instance;
			
			unitState.HouseId = houseState.Id;
			houseState.Units.Add(unitState.Id);
		}

		void AssignNewId(UnitState state) {
			var data = _stateManager.SaveData.UnitData;
			data.MaxUnitId++;
			state.Instance.Id = data.MaxUnitId;
		}

		void Prespawn(UnitState.Data state) {
			var instance = SpawnPrefab();
			if ( !instance ) {
				return;
			}
			instance.State.Apply(state);
		}

		UnitSetup SpawnPrefab() {
			var instance = _factory.Create();
			var root = GameObject.FindObjectOfType<UnitRoot>();
			instance.transform.SetParent(root.transform);
			return instance;
		}
	}
}