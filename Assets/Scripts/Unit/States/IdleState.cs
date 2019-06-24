namespace CityManager.Unit.States {
	public class IdleState : UnitStateMachine.State {
		public override void Enter() {
			Setup.SetVisible(false);
		}

		public override void Update(float _) {
			if ( Setup.State.Data.WorkPlaceId > 0 ) {
				Owner.StartState(new GoToWorkState());
			}
		}

		public override void Exit() {
			Setup.SetVisible(true);
		}
	}
}