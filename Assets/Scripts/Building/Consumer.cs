using CityManager.Utils;
using UnityEngine.Assertions;

namespace CityManager.Building {
	public class Consumer : InstancesHolder<Consumer> {
		public BuildingSetup Setup;
		public string[]      Resources;

		void OnValidate() {
			Assert.IsNotNull(Setup);
			AssertExt.IsNotEmpty(Resources);
		}

		public bool TryConsume() {
			var storage = Setup.Storage;
			if ( !storage ) {
				return true;
			}
			foreach ( var resource in Resources ) {
				if ( !storage.HasResource(resource, 1) ) {
					return false;
				}
			}
			foreach ( var resource in Resources ) {
				storage.TryGetResource(resource, 1);
			}
			return true;
		}
	}
}