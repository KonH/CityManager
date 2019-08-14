using UnityEngine;
using UnityEngine.Assertions;

namespace CityManager.Building {
	public sealed class BuildingSetup : MonoBehaviour {
		public BuildingPlaceholder Placeholder;
		public GameObject          Body;
		public Transform           EntryPoint;
		public BuildingState       State;
		public Producer            Producer;
		public Consumer            Consumer;
		public Storage             Storage;

		void OnValidate() {
			Assert.IsNotNull(Placeholder);
			Assert.IsNotNull(Body);
			Assert.IsNotNull(State);
		}

		void Awake() {
			State.Owner = this;
			if ( Producer ) {
				Producer.Owner = this;
			}
			if ( Consumer ) {
				Consumer.Owner = this;
			}
			if ( Storage ) {
				Storage.Owner = this;
			}
		}
	}
}
