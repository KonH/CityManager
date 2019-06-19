using UnityEngine;
using UnityEngine.Assertions;
using CityManager.Utils;

namespace CityManager.Building {
	public class BuildingSetup : MonoBehaviour {
		public string              Name;
		public BuildingPlaceholder Placeholder;
		public GameObject          Body;

		void OnValidate() {
			AssertExt.IsNotNullOrWhiteSpace(Name);
			Assert.IsNotNull(Placeholder);
			Assert.IsNotNull(Body);
		}
	}
}
