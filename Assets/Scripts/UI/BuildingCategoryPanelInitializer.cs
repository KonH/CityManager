using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;
using CityManager.Installer;

namespace CityManager.UI {
	public class BuildingCategoryPanelInitializer : MonoBehaviour {
		public BuildingPanelInitializer BuildingPanelInitializer;
		
		string[]                      _categories;
		BuildingCategoryPanel.Factory _factory;

		Dictionary<string, BuildingCategoryPanel> _panels = new Dictionary<string, BuildingCategoryPanel>();

		[Inject]
		public void Init(BuildingInstaller.BuildingSet buildingSet, BuildingCategoryPanel.Factory factory) {
			_categories = buildingSet.CategoryNames;
			_factory    = factory;
			UpdateState();
			SelectEmptyCategory();
		}

		void OnValidate() {
			Assert.IsNotNull(BuildingPanelInitializer);
		}

		void UpdateState() {
			foreach ( var category in _categories ) {
				var instance = _factory.Create(category, OnClick);
				instance.transform.SetParent(transform, false);
				_panels.Add(category, instance);
			}
		}

		void SelectEmptyCategory() {
			OnClick(string.Empty);
		}

		void OnClick(string categoryName) {
			var isExist = false;
			foreach ( var pair in _panels ) {
				var curCategoryName = pair.Key;
				var curPanel        = pair.Value;
				var isCurrent       = (categoryName == curCategoryName);
				curPanel.UpdateInteractable(!isCurrent);
				isExist = isExist || isCurrent;
			}
			if ( isExist ) {
				BuildingPanelInitializer.Show(categoryName);
			}
		}
	}
}
