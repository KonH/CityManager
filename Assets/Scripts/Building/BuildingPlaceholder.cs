using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using CityManager.Utils;
using CityManager.Utils.Mouse;
using CityManager.Utils.Collisions;

namespace CityManager.Building {
	public class BuildingPlaceholder : MonoBehaviour {
		public CollisionState[] Parts;
		public MousePlacer      Placer;

		GameObject _owner;
		GameObject _body;
		
		void OnValidate() {
			AssertExt.IsNotEmpty(Parts);
			Assert.IsNotNull(Placer);
		}

		public void Attach(GameObject owner, GameObject body) {
			_owner = owner;
			_body  = body;
			_body.SetActive(false);
			Placer.Init(Camera.main, owner.transform);
		}

		public void TryPlace() {
			var canPlace = Parts.All(p => !p.Triggered);
			if ( canPlace ) {
				Place();
			}
		}

		public void CancelPlace() {
			Destroy(_owner);
		}

		void Place() {
			Destroy(gameObject);
			_body.SetActive(true);
		}
	}
}
