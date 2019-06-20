namespace CityManager.Unit.States {
	public class IdleState : UnitStateMachine.State {
		public override void Enter() {
			Setup.Render.SetActive(false);
			Setup.Movement.Agent.enabled = false;
		}

		public override void Update() {}
	}
}