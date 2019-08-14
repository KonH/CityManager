using CityManager.Building;
using UnityEngine.Assertions;

namespace CityManager.Unit.States {
	public sealed class GoToWorkState : UnitStateMachine.State {
		public override void Enter() {
			var wantedId = Setup.State.Data.WorkPlaceId;
			var workPlace = BuildingState.FindStateById(wantedId);
			Assert.IsNotNull(workPlace);
			var target = workPlace.Owner.EntryPoint;
			Setup.SetVisible(true);
			Setup.Movement.StartMoving(target, OnFinished);
		}

		void OnFinished() {
			Owner.StartState(new WorkReadyState());
		}
	}
}