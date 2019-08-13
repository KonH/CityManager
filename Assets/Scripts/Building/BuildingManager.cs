using UnityEngine;
using Zenject;
using JetBrains.Annotations;
using CityManager.Installer;

namespace CityManager.Building {
	public class BuildingManager : IInitializable {
		readonly BuildingInstaller.BuildingSet _buildingSet;
		readonly StateManager                  _stateManager;
		
		public BuildingManager(BuildingInstaller.BuildingSet buildingSet, StateManager stateManager) {
			_buildingSet  = buildingSet;
			_stateManager = stateManager;
		}
		
		public void Initialize() {
			var saveData = _stateManager.Data;
			foreach ( var building in saveData.Buildings ) {
				Prebuild(building);
			}
		}

		public void Build(string category, string buildingName) {
			var instance = SpawnPrefab(category, buildingName);
			if ( !instance ) {
				return;
			}
			instance.Body.SetActive(false);
			instance.Placeholder.Attach(instance.transform, confirm => OnBuildingPlaced(instance, confirm));
		}

		[CanBeNull]
		public House GetHouseWithFreePlaces() {
			foreach ( var house in House.Instances ) {
				if ( house.HasFreePlaces ) {
					return house;
				}
			}
			return null;
		}

		void OnBuildingPlaced(BuildingSetup instance, bool confirm) {
			if ( confirm ) {
				RemovePlaceholder(instance);
				instance.Body.SetActive(true);
				AssignNewId(instance.State);
				instance.State.enabled = true;
			} else {
				GameObject.Destroy(instance.gameObject);
			}
		}

		void AssignNewId(BuildingState state) {
			var data = _stateManager.Data.BuildingData;
			data.MaxBuildingId++;
			state.Data.Id = data.MaxBuildingId;
		}

		void Prebuild(BuildingData state) {
			var instance = SpawnPrefab(state.Category, state.Name);
			if ( !instance ) {
				return;
			}
			RemovePlaceholder(instance);
			instance.State.Apply(state);
			instance.State.enabled = true;
		}
		
		[CanBeNull]
		BuildingSetup GetPrefab(string category, string buildingName) {
			if ( !_buildingSet.Categories.TryGetValue(category, out var setups) ) {
				return null;
			}
			var prefab = setups.Find(s => s.BuildingName == buildingName);
			return prefab;
		}

		[CanBeNull]
		BuildingSetup SpawnPrefab(string category, string buildingName) {
			var prefab = GetPrefab(category, buildingName);
			if ( !prefab ) {
				return null;
			}
			var root = BuildingRoot.Instance;
			var instance = GameObject.Instantiate(prefab, root.transform);
			return instance;
		}

		void RemovePlaceholder(BuildingSetup instance) {
			GameObject.Destroy(instance.Placeholder.gameObject);
			instance.Placeholder = null;
		}
	}
}
