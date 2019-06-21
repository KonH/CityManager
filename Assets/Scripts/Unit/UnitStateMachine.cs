using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace CityManager.Unit {
	public class UnitStateMachine : MonoBehaviour {
		public abstract class State {
			public UnitSetup        Setup;
			public UnitStateMachine Owner;
			
			public virtual void Enter() {}
			public virtual void Update() {}
			public virtual void Exit() {}
		}

		public UnitSetup Setup;
		
		public State CurrentState { get; private set; }

		void OnValidate() {
			Assert.IsNotNull(Setup);
		}

		public void StartState(string stateName) {
			var type = Type.GetType(stateName);
			var state = Activator.CreateInstance(type) as State;
			EnterState(state);
		}

		public void StartState(State state) {
			CurrentState?.Exit();
			EnterState(state);
		}

		void EnterState(State newState) {
			CurrentState = newState;
			CurrentState.Owner = this;
			CurrentState.Setup = Setup;
			CurrentState.Enter();
		}
		
		public void Update() {
			CurrentState.Update();
		}
	}
}