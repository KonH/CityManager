using UnityEngine.Assertions;
using CityManager.Building;

namespace CityManager.Unit.States {
	public class WorkReadyState : UnitStateMachine.State {
		Storage  _storage;
		Producer _producer;
		
		public override void Enter() {
			Setup.SetVisible(false);
			var state = BuildingState.FindStateById(Setup.State.Data.WorkPlaceId);
			Assert.IsNotNull(state);
			var setup = state.Setup;
			_storage  = setup.Storage;
			_producer = setup.Producer;
		}

		public override void Update() {
			var wantedResource = _producer.Resource;
			if ( Consumer.HasFreeInstancesFor(wantedResource) && _storage.TryGetResource(wantedResource, 1) ) {
				Setup.SetInventory(wantedResource);
				Owner.StartState(new WorkTransferState());
				return;
			}
			if ( _producer.TryConsume() ) {
				Owner.StartState(new WorkProduceState());
			}
		}
	}
}