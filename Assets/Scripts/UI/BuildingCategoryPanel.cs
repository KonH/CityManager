using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using TMPro;
using Zenject;

namespace CityManager.UI {
	public class BuildingCategoryPanel : MonoBehaviour {
		public class Settings {
			public readonly string         Name;
			public readonly Action<string> OnClick;
			
			public Settings(string name, Action<string> onClick) {
				Name    = name;
				OnClick = onClick;
			}
		}
		
		public class Factory : PlaceholderFactory<Settings, BuildingCategoryPanel> {}

		public Button   SelectButton;
		public TMP_Text NameText;

		void OnValidate() {
			Assert.IsNotNull(SelectButton);
			Assert.IsNotNull(NameText);
		}

		[Inject]
		public void Init(Settings settings) {
			NameText.text = settings.Name;
			SelectButton.onClick.AddListener(() => settings.OnClick(settings.Name));
		}

		public void UpdateInteractable(bool state) {
			SelectButton.interactable = state;
		}
	}
}
