﻿using UnityEngine;
using UnityEngine.Assertions;
using CityManager.Utils;

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

		void OnValidate() {
			AssertExt.IsNotNullOrWhiteSpace(CategoryName);
			AssertExt.IsNotNullOrWhiteSpace(BuildingName);
			Assert.IsNotNull(Placeholder);
			Assert.IsNotNull(Body);
			Assert.IsNotNull(State);
		}
	}
}
