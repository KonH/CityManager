using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace CityManager.Unit {
	public class UnitSetup : MonoBehaviour {
		public class Factory : PlaceholderFactory<UnitSetup> {}

		public UnitState        State;
		public UnitStateMachine StateMachine;
		public Movement         Movement;
		public GameObject       Render;

		void OnValidate() {
			Assert.IsNotNull(State);
			Assert.IsNotNull(StateMachine);
			Assert.IsNotNull(Movement);
			Assert.IsNotNull(Render);
		}

		public void SetVisible(bool state) {
			Render.SetActive(state);
			Movement.Agent.enabled = state;
		}
	}
}