using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using TMPro;
using Zenject;

namespace CityManager.UI {
	public sealed class BuildingCategoryPanel : MonoBehaviour {
		public sealed class Settings {
			public readonly string         Name;
			public readonly Action<string> OnClick;

			public Settings(string name, Action<string> onClick) {
				Name    = name;
				OnClick = onClick;
			}
		}

		public sealed class Factory : PlaceholderFactory<Settings, BuildingCategoryPanel> {}

		[SerializeField] Button   SelectButton = null;
		[SerializeField] TMP_Text NameText     = null;

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
