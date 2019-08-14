using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CityManager.Building {
	public sealed class Storage : MonoBehaviour {
		[NonSerialized]
		public BuildingSetup Owner = null;

		[SerializeField] int Capacity = 0;

		public int OccupiedSpace {
			get {
				var occupiedSpace = 0;
				foreach ( var pair in Resources ) {
					occupiedSpace += pair.Value;
				}
				return occupiedSpace;
			}
		}

		public int FreeSpace => Capacity - OccupiedSpace;

		public bool HasFreeSpace => FreeSpace > 0;

		Dictionary<string, int> Resources => Owner.State.Data.Resources;

		void OnValidate() {
			Assert.IsTrue(Capacity > 0);
		}

		public bool AddResource(string resource, int amount) {
			if ( !HasFreeSpace ) {
				return false;
			}
			Resources.TryGetValue(resource, out var count);
			var actualAmount = Mathf.Min(amount, FreeSpace);
			Resources[resource] = count + actualAmount;
			return true;
		}

		public bool HasResource(string resource, int amount) {
			return Resources.TryGetValue(resource, out var count) && (count >= amount);
		}

		public bool TryGetResource(string resource, int amount) {
			if ( !Resources.TryGetValue(resource, out var count) ) {
				return false;
			}
			if ( count < amount ) {
				return false;
			}
			Resources[resource] = count - amount;
			return true;
		}

		[ContextMenu("AddGoldOreResource")]
		public void AddGoldOreResource() => AddResource("GoldOre", 1);

		[ContextMenu("AddGoldBarResource")]
		public void AddGoldBarResource() => AddResource("GoldBar", 1);
	}
}