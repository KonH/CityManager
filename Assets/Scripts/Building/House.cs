using UnityEngine;
using UnityEngine.Assertions;

namespace CityManager.Building {
	public class House : MonoBehaviour {
		public int           Capacity;
		public BuildingState State;

		void OnValidate() {
			Assert.IsNotNull(State);
		}
	}
}