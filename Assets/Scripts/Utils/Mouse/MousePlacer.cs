using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

namespace CityManager.Utils.Mouse {
	public class MousePlacer : MonoBehaviour {
		[Header("Settings")]
		public Camera    Camera;
		public bool      SnapToGrid;
		public string    RaycastLayer;
		public Transform Target;

		[Header("Callbacks")]
		public UnityEvent OnConfirm;
		public UnityEvent OnCancel;

		int          _layerMask = 0;
		RaycastHit[] _hits      = new RaycastHit[1];

		void OnValidate() {
			Assert.IsNotNull(Camera);
			Assert.IsNotNull(Target);
		}

		void Awake() {
			_layerMask = LayerMask.GetMask(RaycastLayer);
		}

		void Update() {
			UpdatePosition();
			UpdateState();
		}

		void UpdatePosition() {
			var mouseRay = Camera.ScreenPointToRay(Input.mousePosition);
			var hitCount = Physics.RaycastNonAlloc(mouseRay, _hits, Mathf.Infinity, _layerMask);
			if ( hitCount == 0 ) {
				return;
			}
			var hitPosition = _hits[0].point;
			Target.position = SnapToGrid ? Snap(hitPosition) : hitPosition;
		}

		void UpdateState() {
			var confirmed = Input.GetMouseButtonDown(0);
			var canceled  = Input.GetMouseButtonDown(1);
			if ( confirmed ) {
				OnConfirm.Invoke();
			}
			if ( canceled ) {
				OnCancel.Invoke();
			}
		}

		Vector3 Snap(Vector3 input) {
			return new Vector3(
				Mathf.Round(input.x),
				Mathf.Round(input.y),
				Mathf.Round(input.z));
		}

		void OnDrawGizmosSelected() {
			Gizmos.DrawLine(Camera.transform.position, Target.position);
		}
	}
}