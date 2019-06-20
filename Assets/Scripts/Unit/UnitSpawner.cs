using UnityEngine;
using Zenject;

namespace CityManager.Unit {
	public class UnitSpawner : MonoBehaviour {
		UnitManager _manager;

		float _testTimer;
		
		[Inject]
		public void Init(UnitManager manager) {
			_manager = manager;
		}
		
		void Update() {
			TrySpawn();
		}

		void TrySpawn() {
			_testTimer += Time.deltaTime;
			if ( _testTimer < 3.0f ) {
				return;
			}
			_testTimer = 0.0f;
			var instance = _manager.Spawn();
			var instanceTrans = instance.transform;
			var rootTrans = transform;
			instanceTrans.position = rootTrans.position;
			instanceTrans.rotation = rootTrans.rotation;
		}
	}
}