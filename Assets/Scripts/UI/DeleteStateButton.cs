﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using Zenject;

namespace CityManager.UI {
	public class DeleteStateButton : MonoBehaviour {
		public Button Button;

		StateManager _manager;
		
		void OnValidate() {
			Assert.IsNotNull(Button);
		}

		[Inject]
		public void Init(StateManager manager) {
			_manager = manager;
			Button.onClick.AddListener(Delete);
		}

		void Delete() {
			_manager.Delete();
		}
	}
}
