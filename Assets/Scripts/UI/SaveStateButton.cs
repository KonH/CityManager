﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using Zenject;

namespace CityManager.UI {
	public sealed class SaveStateButton : MonoBehaviour {
		[SerializeField] Button Button = null;

		StateManager _manager;

		void OnValidate() {
			Assert.IsNotNull(Button);
		}

		[Inject]
		public void Init(StateManager manager) {
			_manager = manager;
			Button.onClick.AddListener(Save);
		}

		void Save() {
			_manager.Save();
		}
	}
}
