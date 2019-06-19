using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using CityManager.Utils.Collisions;

namespace CityManager.Building {
	public class BuildingCore : MonoBehaviour {
		public bool             Ready;
		public GameObject       PlaceholderRoot;
		public CollisionState[] PlaceholderParts;
		public GameObject       BuildingRoot;
		public Transform        EntryPoint;

		bool CanStopBuilding => PlaceholderParts.All(p => !p.Triggered);
		
		void OnValidate() {
			Assert.IsNotNull(PlaceholderRoot);
			Assert.IsNotNull(BuildingRoot);
			Assert.IsNotNull(EntryPoint);
		}

		void Awake() {
			if ( Ready ) {
				StopBuilding();
			} else {
				StartBuilding();
			}
		}

		void StartBuilding() {
			SetAsPlaceholder(true);
		}

		void StopBuilding() {
			SetAsPlaceholder(false);
		}

		public void TryStopBuilding() {
			if ( CanStopBuilding ) {
				StopBuilding();
			}
		}

		void SetAsPlaceholder(bool isPlaceholderActive) {
			PlaceholderRoot.SetActive(isPlaceholderActive);
			BuildingRoot.SetActive(!isPlaceholderActive);
		}
	}
}
