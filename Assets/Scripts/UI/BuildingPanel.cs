using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using TMPro;
using Zenject;

namespace CityManager.UI {
	public class BuildingPanel : MonoBehaviour {
		public class Settings {
			public readonly string         Name;
			public readonly Action<string> OnClick;
			
			public Settings(string name, Action<string> onClick) {
				Name    = name;
				OnClick = onClick;
			}
		}
		
		public class Factory : PlaceholderFactory<Settings, BuildingPanel> {}
		
		public Button   BuildButton;
		public TMP_Text NameText;

		[Inject]
		public void Init(Settings settings) {
			NameText.text = settings.Name;
			BuildButton.onClick.AddListener(() => settings.OnClick(settings.Name));
		}
		
		void OnValidate() {
			Assert.IsNotNull(BuildButton);
			Assert.IsNotNull(NameText);
		}
	}
}
