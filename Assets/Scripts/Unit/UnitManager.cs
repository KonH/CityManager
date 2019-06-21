using Zenject;

namespace CityManager.Unit {
	public class UnitManager : IInitializable {
		UnitSetup.Factory _factory;
		StateManager      _stateManager;
		
		public UnitManager(UnitSetup.Factory factory, StateManager stateManager) {
			_factory      = factory;
			_stateManager = stateManager;
		}
		
		public void Initialize() {
			var saveData = _stateManager.Data;
			foreach ( var unit in saveData.Units ) {
				Prespawn(unit);
			}
		}

		public UnitSetup Spawn() {
			var instance = SpawnPrefab();
			AssignNewId(instance.State);
			return instance;
		}

		void AssignNewId(UnitState state) {
			var data = _stateManager.Data.UnitData;
			data.MaxUnitId++;
			state.Data.Id = data.MaxUnitId;
		}

		void Prespawn(UnitData state) {
			var instance = SpawnPrefab();
			if ( !instance ) {
				return;
			}
			instance.State.Apply(state);
		}

		UnitSetup SpawnPrefab() {
			var instance = _factory.Create();
			var root = UnitRoot.Instance;
			instance.transform.SetParent(root.transform);
			return instance;
		}
	}
}