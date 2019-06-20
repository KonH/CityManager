using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace CityManager.Unit {
	public class UnitSetup : MonoBehaviour {
		public class Factory : PlaceholderFactory<UnitSetup> {}

		public UnitState State;

		void OnValidate() {
			Assert.IsNotNull(State);
		}
	}
}