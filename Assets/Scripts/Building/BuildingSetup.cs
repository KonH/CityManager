using UnityEngine;
using CityManager.Utils;
using UnityEngine.Assertions;

namespace CityManager.Building {
	public class BuildingSetup : MonoBehaviour {
		public string              CategoryName;
		public string              BuildingName;
		public BuildingPlaceholder Placeholder;
		public GameObject          Body;
		public Transform           EntryPoint;
		public BuildingState       State;
		public Producer            Producer;
		public Consumer            Consumer;
		public Storage             Storage;
		public WorkPlace           WorkPlace;

		void OnValidate() {
			AssertExt.IsNotNullOrWhiteSpace(CategoryName);
			AssertExt.IsNotNullOrWhiteSpace(BuildingName);
			Assert.IsNotNull(Placeholder);
			Assert.IsNotNull(Body);
			Assert.IsNotNull(State);
		}
	}
}
