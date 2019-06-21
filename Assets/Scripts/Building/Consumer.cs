using UnityEngine.Assertions;
using JetBrains.Annotations;
using CityManager.Utils;

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

		public static bool HasFreeInstancesFor(string resource) {
			return TryGetInstanceFor(resource) != null;
		}

		[CanBeNull]
		public static Consumer TryGetInstanceFor(string resource) {
			foreach ( var instance in Instances ) {
				var isFound = false;
				foreach ( var res in instance.Resources ) {
					if ( res == resource ) {
						isFound = true;
						break;
					}
				}
				if ( !isFound ) {
					continue;
				}
				if ( instance.Setup.Storage.HasFreeSpace ) {
					return instance;
				}
			}
			return null;
		}
	}
}