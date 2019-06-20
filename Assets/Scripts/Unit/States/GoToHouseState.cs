using System.Linq;
using CityManager.Building;
using UnityEngine;

namespace CityManager.Unit.States {
	public class GoToHouseState : UnitStateMachine.State {
		public override void Enter() {
			var wantedId = Setup.State.Instance.HouseId;
			var house = GameObject.FindObjectsOfType<House>().First(h => h.State.Instance.Id == wantedId);
			var target = house.GetComponentInParent<BuildingSetup>().EntryPoint;
			Setup.Movement.StartMoving(target, OnFinished);
		}

		public override void Update() {}

		void OnFinished() {
			Owner.StartState(new IdleState());
		}
	}
}