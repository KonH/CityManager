using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using TMPro;
using Zenject;

namespace CityManager.UI {
	public class BuildingPanel : MonoBehaviour {
		public class Factory : PlaceholderFactory<string, Action<string>, BuildingPanel> {}
		
		public Button   BuildButton;
		public TMP_Text NameText;

		[Inject]
		public void Init(string buildingName, Action<string> onClick) {
			NameText.text = buildingName;
			BuildButton.onClick.AddListener(() => onClick(buildingName));
		}
		
		void OnValidate() {
			Assert.IsNotNull(BuildButton);
			Assert.IsNotNull(NameText);
		}
	}
}
