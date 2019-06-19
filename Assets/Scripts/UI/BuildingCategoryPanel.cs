using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using TMPro;
using Zenject;

namespace CityManager.UI {
	public class BuildingCategoryPanel : MonoBehaviour {
		public class Factory : PlaceholderFactory<string, Action<string>, BuildingCategoryPanel> {}

		public Button   SelectButton;
		public TMP_Text NameText;

		void OnValidate() {
			Assert.IsNotNull(SelectButton);
			Assert.IsNotNull(NameText);
		}

		[Inject]
		public void Init(string categoryName, Action<string> onClick) {
			NameText.text = categoryName;
			SelectButton.onClick.AddListener(() => onClick(categoryName));
		}

		public void UpdateInteractable(bool state) {
			SelectButton.interactable = state;
		}
	}
}
