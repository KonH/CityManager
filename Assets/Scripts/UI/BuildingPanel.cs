using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using TMPro;
using Zenject;

namespace CityManager.UI {
	public sealed class BuildingPanel : MonoBehaviour {
		public sealed class Settings {
			public readonly string         Name;
			public readonly Action<string> OnClick;

			public Settings(string name, Action<string> onClick) {
				Name    = name;
				OnClick = onClick;
			}
		}

		public sealed class Factory : PlaceholderFactory<Settings, BuildingPanel> {}

		[SerializeField] public Button   BuildButton = null;
		[SerializeField] public TMP_Text NameText    = null;

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
