using CityManager.Building;
using UnityEngine.Assertions;

namespace CityManager.Unit.States {
	public class GoToHouseState : UnitStateMachine.State {
		public override void Enter() {
			var wantedId = Setup.State.Data.HouseId;
			var house = BuildingState.FindStateById(wantedId);
			Assert.IsNotNull(house);
			var target = house.Setup.EntryPoint;
			Setup.Movement.StartMoving(target, OnFinished);
		}

		void OnFinished() {
			Owner.StartState(new IdleState());
		}
	}
}