using UnityEngine;
using Zenject;
using CityManager.Building;
using CityManager.Unit.States;

namespace CityManager.Unit {
	public sealed class UnitSpawner : MonoBehaviour {
		BuildingManager _buildingManager;
		UnitManager     _unitManager;

		float _timer;

		[Inject]
		public void Init(BuildingManager buildingManager, UnitManager unitManager) {
			_buildingManager = buildingManager;
			_unitManager     = unitManager;
		}

		void Update() {
			TrySpawn();
		}

		void TrySpawn() {
			if ( _timer < 1.5f ) {
				_timer += Time.deltaTime;
				return;
			}
			_timer = 0.0f;
			var house = _buildingManager.GetHouseWithFreePlaces();
			if ( !house ) {
				return;
			}
			var instance = _unitManager.Spawn();
			house.AddUnit(instance);
			instance.StateMachine.StartState(new GoToHouseState());
			var instanceTrans = instance.transform;
			var rootTrans = transform;
			instanceTrans.position = rootTrans.position;
			instanceTrans.rotation = rootTrans.rotation;
		}
	}
}