using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using CityManager.UI;
using CityManager.Building;

namespace CityManager.Installer {
	[CreateAssetMenu(fileName = "BuildingInstaller", menuName = "Installers/BuildingInstaller")]
	public class BuildingInstaller : ScriptableObjectInstaller<BuildingInstaller> {
		public class BuildingSet {
			public Dictionary<string, List<BuildingSetup>> Categories    = new Dictionary<string, List<BuildingSetup>>();
			public string[]                                CategoryNames = null;
		}
		
		public BuildingSetup[]       Buildings;
		public BuildingCategoryPanel BuildingCategoryPanelPrefab;
		public BuildingPanel         BuildingPanelPrefab;
		
		public override void InstallBindings() {
			Container.BindInstance(CreateBuildingSet());
			Container.BindFactory<BuildingCategoryPanel.Settings, BuildingCategoryPanel, BuildingCategoryPanel.Factory>().FromComponentInNewPrefab(BuildingCategoryPanelPrefab);
			Container.BindFactory<BuildingPanel.Settings, BuildingPanel, BuildingPanel.Factory>().FromComponentInNewPrefab(BuildingPanelPrefab);
			Container.Bind(typeof(BuildingManager), typeof(IInitializable)).To<BuildingManager>().AsSingle();
		}

		BuildingSet CreateBuildingSet() {
			var set = new BuildingSet();
			foreach ( var building in Buildings ) {
				var category     = building.GetComponent<BuildingCategory>();
				var categoryName = category.Name;
				if ( !set.Categories.TryGetValue(categoryName, out var setups) ) {
					setups = new List<BuildingSetup>();
					set.Categories.Add(categoryName, setups);
				}
				setups.Add(building);
			}
			set.CategoryNames = set.Categories.Keys.ToArray();
			return set;
		}
	}
}