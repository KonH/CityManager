using System;
using UnityEngine.Assertions;
using JetBrains.Annotations;
using CityManager.Utils;

namespace CityManager.Building {
	public sealed class Consumer : InstancesHolder<Consumer> {
		[NonSerialized]
		public BuildingSetup Owner;

		public string[] Resources;

		void OnValidate() {
			AssertExt.IsNotEmpty(Resources);
		}

		public bool TryConsume() {
			var storage = Owner.Storage;
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
				if ( instance.Owner.Storage.HasFreeSpace ) {
					return instance;
				}
			}
			return null;
		}
	}
}