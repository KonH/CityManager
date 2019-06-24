using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace CityManager.Unit {
	public class UnitStateMachine : MonoBehaviour {
		public abstract class State {
			public UnitSetup        Setup;
			public UnitStateMachine Owner;
			public float            Progress;
			
			public virtual void Enter() {}
			public virtual void Update(float dt) {}
			public virtual void Exit() {}
		}

		public UnitSetup Setup;
		
		public State CurrentState { get; private set; }

		void OnValidate() {
			Assert.IsNotNull(Setup);
		}

		public void StartState(string stateName, float progress) {
			var type = Type.GetType(stateName);
			var state = Activator.CreateInstance(type) as State;
			EnterState(state, progress);
		}

		public void StartState(State state, float progress = 0.0f) {
			CurrentState?.Exit();
			EnterState(state, progress);
		}

		void EnterState(State newState, float progress) {
			CurrentState = newState;
			CurrentState.Owner = this;
			CurrentState.Setup = Setup;
			CurrentState.Progress = progress;
			CurrentState.Enter();
		}
		
		public void Update() {
			CurrentState.Update(Time.deltaTime);
		}
	}
}