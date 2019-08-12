using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using CityManager.Utils;
using CityManager.Utils.Mouse;
using CityManager.Utils.Keyboard;
using CityManager.Utils.Collisions;

namespace CityManager.Building {
	public class BuildingPlaceholder : MonoBehaviour {
		public CollisionState[] Parts;
		public MousePlacer      Placer;
		public KeyboardRotate   Rotator;
		
		Action<bool> _onPlace;
		
		void OnValidate() {
			AssertExt.IsNotEmpty(Parts);
			Assert.IsNotNull(Placer);
			Assert.IsNotNull(Rotator);
		}

		public void Attach(Transform rootTransform, Action<bool> onPlace) {
			_onPlace = onPlace;
			Placer.Init(Camera.main, rootTransform);
			Rotator.Init(rootTransform);
		}

		public void TryPlace() {
			Assert.IsNotNull(_onPlace);
			var canPlace = Parts.All(p => !p.Triggered);
			if ( canPlace ) {
				Place();
			}
		}

		public void CancelPlace() {
			_onPlace(false);
		}

		void Place() {
			_onPlace(true);
		}
	}
}
