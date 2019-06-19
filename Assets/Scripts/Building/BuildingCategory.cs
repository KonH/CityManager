using UnityEngine;
using CityManager.Utils;

namespace CityManager.Building {
	public class BuildingCategory : MonoBehaviour {
		public string Name;

		void OnValidate() {
			AssertExt.IsNotNullOrWhiteSpace(Name);
		}
	}
}
