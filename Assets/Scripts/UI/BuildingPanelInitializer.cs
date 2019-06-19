using System.Collections.Generic;
using UnityEngine;
using Zenject;
using CityManager.Installer;

namespace CityManager.UI {
	public class BuildingPanelInitializer : MonoBehaviour {
		BuildingInstaller.BuildingSet _buildingSet;
		BuildingPanel.Factory         _panelFactory;
		
		List<BuildingPanel> _panels = new List<BuildingPanel>();

		string _curCategory;
		
		[Inject]
		public void Init(BuildingInstaller.BuildingSet buildingSet, BuildingPanel.Factory panelFactory) {
			_buildingSet  = buildingSet;
			_panelFactory = panelFactory;
		}
		
		public void Show(string categoryName) {
			_curCategory = categoryName;
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
				var instance = _panelFactory.Create(setup.Name, OnClick);
				instance.transform.SetParent(transform);
				_panels.Add(instance);
			}
		}

		void OnClick(string buildingName) {
			if ( !_buildingSet.Categories.TryGetValue(_curCategory, out var setups) ) {
				return;
			}
			var prefab = setups.Find(s => s.Name == buildingName);
			if ( !prefab ) {
				return;
			}
			var instance = Instantiate(prefab);
			instance.Placeholder.Attach(instance.gameObject, instance.Body);
		}
	}
}
