using System;
using UnityEngine;
using UnityEngine.Assertions;
using CityManager.Utils;

namespace CityManager.Building {
	public sealed class Producer : MonoBehaviour {
		[NonSerialized]
		public BuildingSetup Owner;

		public string Resource;
		public float  ProduceTime;

		void OnValidate() {
			AssertExt.IsNotNullOrWhiteSpace(Resource);
			Assert.IsTrue(ProduceTime > 0);
		}

		public bool TryConsume() {
			var consumer = Owner.Consumer;
			if ( !consumer ) {
				return true;
			}
			return consumer.TryConsume();
		}

		public void Produce() {
			var storage = Owner.Storage;
			if ( !storage ) {
				return;
			}
			storage.AddResource(Resource, 1);
		}
	}
}