using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace CityManager.Unit {
	public sealed class UnitSetup : MonoBehaviour {
		public sealed class Factory : PlaceholderFactory<UnitSetup> {}

		[Serializable]
		public sealed class InventoryPart {
			public string     Name;
			public GameObject Render;
		}

		public UnitState           State;
		public UnitStateMachine    StateMachine;
		public Movement            Movement;
		public GameObject          Render;
		public List<InventoryPart> InventoryParts;

		void OnValidate() {
			Assert.IsNotNull(State);
			Assert.IsNotNull(StateMachine);
			Assert.IsNotNull(Movement);
			Assert.IsNotNull(Render);
		}

		void Awake() {
			State.Owner = this;
			StateMachine.Owner = this;
		}

		public void SetVisible(bool state) {
			Render.SetActive(state);
			Movement.Agent.enabled = state;
		}

		public void SetInventory(string resource) {
			foreach ( var part in InventoryParts ) {
				part.Render.SetActive(part.Name == resource);
			}
			State.Data.Inventory = resource;
		}
	}
}