using UnityEngine;
using UnityEngine.Assertions;
using CityManager.Building;

namespace CityManager.Unit.States {
	public class WorkProduceState : UnitStateMachine.State {
		float    _startTime;
		Storage  _storage;
		Producer _producer;
		
		public override void Enter() {
			_startTime = Time.realtimeSinceStartup;
			var state = BuildingState.FindStateById(Setup.State.Data.WorkPlaceId);
			Assert.IsNotNull(state);
			var setup = state.Setup;
			_storage  = setup.Storage;
			_producer = setup.Producer;
			Setup.SetVisible(false);
		}

		public override void Update() {
			if ( Time.realtimeSinceStartup > _startTime + 10.0f ) {
				_producer.Produce();
				Owner.StartState(new WorkReadyState());
			}
		}
	}
}