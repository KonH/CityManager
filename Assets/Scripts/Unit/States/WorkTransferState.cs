using UnityEngine.Assertions;
using CityManager.Building;

namespace CityManager.Unit.States {
	public class WorkTransferState : UnitStateMachine.State {
		string   _wantedResource;
		Consumer _consumer;
		
		public override void Enter() {
			_wantedResource = Setup.State.Data.Inventory;
			_consumer          = Consumer.TryGetInstanceFor(_wantedResource);
			Assert.IsNotNull(_consumer);
			var target = _consumer.Setup.EntryPoint;
			Setup.SetVisible(true);
			Setup.Movement.StartMoving(target, OnFinished);
		}

		void OnFinished() {
			Setup.State.Data.Inventory = string.Empty;
			_consumer.Setup.Storage.AddResource(_wantedResource, 1);
			Owner.StartState(new IdleState());
		}
	}
}