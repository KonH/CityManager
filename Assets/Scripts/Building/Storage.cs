using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CityManager.Building {
	public class Storage : MonoBehaviour {
		public BuildingSetup Setup;
		public int           Capacity;

		public bool HasFreeSpace {
			get {
				var occupiedSpace = 0;
				foreach ( var pair in Resources ) {
					occupiedSpace += pair.Value;
				}
				return occupiedSpace < Capacity;
			}
		}
		
		Dictionary<string, int> Resources => Setup.State.Data.Resources;
		
		void OnValidate() {
			Assert.IsNotNull(Setup);
			Assert.IsTrue(Capacity > 0);
		}
		
		public bool AddResource(string resource, int amount) {
			if ( !HasFreeSpace ) {
				return false;
			}
			Resources.TryGetValue(resource, out var count);
			Resources[resource] = count + amount;
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