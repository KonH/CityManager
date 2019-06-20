using System.Collections.Generic;
using UnityEngine;
using Zenject;
using CityManager.Building;
using CityManager.Installer;

namespace CityManager.UI {
	public class BuildingPanelInitializer : MonoBehaviour {
		BuildingInstaller.BuildingSet _buildingSet;
		BuildingPanel.Factory         _panelFactory;
		BuildingManager               _manager;

		List<BuildingPanel> _panels = new List<BuildingPanel>();

		[Inject]
		public void Init(BuildingInstaller.BuildingSet buildingSet, BuildingPanel.Factory panelFactory, BuildingManager manager) {
			_buildingSet  = buildingSet;
			_panelFactory = panelFactory;
			_manager      = manager;
		}
		
		public void Show(string categoryName) {
			HideCurrentPanels();
			ShowForCategory(categoryName);
		}

		void HideCurrentPanels() {
			foreach ( var panel in _panels ) {
				Destroy(panel.gameObject);
			}
			_panels.Clear();
		}

		void ShowForCategory(string categoryName) {
			if ( !_buildingSet.Categories.TryGetValue(categoryName, out var setups) ) {
				return;
			}
			foreach ( var setup in setups ) {
				var settings = new BuildingPanel.Settings(setup.BuildingName, buildingName => _manager.Build(categoryName, buildingName));
				var instance = _panelFactory.Create(settings);
				instance.transform.SetParent(transform);
				_panels.Add(instance);
			}
		}
	}
}
