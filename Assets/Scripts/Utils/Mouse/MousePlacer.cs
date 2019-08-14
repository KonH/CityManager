using UnityEngine;
using UnityEngine.Events;

namespace CityManager.Utils.Mouse {
	public sealed class MousePlacer : MonoBehaviour {
		[Header("Settings")]
		[SerializeField] bool   SnapToGrid   = false;
		[SerializeField] string RaycastLayer = null;

		[Header("Callbacks")]
		[SerializeField] UnityEvent OnConfirm = null;
		[SerializeField] UnityEvent OnCancel  = null;

		Camera       _camera    = null;
		Transform    _target    = null;
		int          _layerMask = 0;
		RaycastHit[] _hits      = new RaycastHit[1];

		public void Init(Camera cam, Transform target) {
			_camera = cam;
			_target = target;
			UpdatePosition();
			UpdateState();
		}

		void Awake() {
			_layerMask = LayerMask.GetMask(RaycastLayer);
		}

		void Update() {
			UpdatePosition();
			UpdateState();
		}

		void UpdatePosition() {
			var mouseRay = _camera.ScreenPointToRay(Input.mousePosition);
			var hitCount = Physics.RaycastNonAlloc(mouseRay, _hits, Mathf.Infinity, _layerMask);
			if ( hitCount == 0 ) {
				return;
			}
			var hitPosition = _hits[0].point;
			_target.position = SnapToGrid ? Snap(hitPosition) : hitPosition;
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
			if ( !Application.isPlaying ) {
				return;
			}
			Gizmos.DrawLine(_camera.transform.position, _target.position);
		}
	}
}