using UnityEngine;

namespace CityManager.Utils.Keyboard {
	public sealed class KeyboardRotate : MonoBehaviour {
		Transform _target;

		public void Init(Transform target) {
			_target = target;
		}

		void Update() {
			var leftRotate = Input.GetKeyDown(KeyCode.Q);
			if ( leftRotate ) {
				_target.Rotate(Vector3.up, 90);
			}
			var rightRotate = Input.GetKeyDown(KeyCode.E);
			if ( rightRotate ) {
				_target.Rotate(Vector3.up, -90);
			}
		}
	}
}
