using UnityEngine.Assertions;
using CityManager.Building;

namespace CityManager.Unit.States {
	public class WorkProduceState : UnitStateMachine.State {
		Producer _producer;

		public override void Enter() {
			var state = BuildingState.FindStateById(Setup.State.Data.WorkPlaceId);
			Assert.IsNotNull(state);
			var setup = state.Setup;
			_producer = setup.Producer;
			Setup.SetVisible(false);
		}

		public override void Update(float dt) {
			Progress += (dt / _producer.ProduceTime);
			if ( Progress < 1.0f ) {
				return;
			}
			_producer.Produce();
			Owner.StartState(new WorkReadyState());
		}
	}
}