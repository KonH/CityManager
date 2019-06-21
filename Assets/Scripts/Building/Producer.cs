using UnityEngine;
using UnityEngine.Assertions;
using CityManager.Utils;

namespace CityManager.Building {
	public class Producer : MonoBehaviour {
		public BuildingSetup Setup;
		public string        Resource;

		void OnValidate() {
			Assert.IsNotNull(Setup);
			AssertExt.IsNotNullOrWhiteSpace(Resource);
		}

		public bool TryConsume() {
			var consumer = Setup.Consumer;
			if ( !consumer ) {
				return true;
			}
			return consumer.TryConsume();
		}

		public void Produce() {
			var storage = Setup.Storage;
			if ( !storage ) {
				return;
			}
			storage.AddResource(Resource, 1);
		}
	}
}