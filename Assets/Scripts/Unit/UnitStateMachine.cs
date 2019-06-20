using System;
using UnityEngine;

namespace CityManager.Unit {
	public class UnitStateMachine : MonoBehaviour {
		public abstract class State {
			public UnitSetup        Setup;
			public UnitStateMachine Owner;
			
			public abstract void Enter();
			public abstract void Update();
		}

		public State CurrentState { get; private set; }

		public void StartState(string stateName) {
			var type = Type.GetType(stateName);
			CurrentState = Activator.CreateInstance(type) as State;
			EnterState();
		}

		public void StartState(State state) {
			CurrentState = state;
			EnterState();
		}

		void EnterState() {
			CurrentState.Owner = this;
			CurrentState.Setup = GetComponent<UnitSetup>();
			CurrentState.Enter();
		}
		
		public void Update() {
			CurrentState.Update();
		}
	}
}