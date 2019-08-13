using UnityEngine;
using UnityEngine.Assertions;

namespace CityManager.Utils.Collisions {
	public class CollisionState : MonoBehaviour {
		public string     RaycastLayer;
		public Vector3    Size;
		public Vector3    Offset;
		public GameObject TriggeredBlock;
		public GameObject NonTriggeredBlock;

		public bool Triggered { get; private set; }

		int        _layerMask = 0;
		Collider[] _hits      = new Collider[4];

		void OnValidate() {
			Assert.IsNotNull(TriggeredBlock);
			Assert.IsNotNull(NonTriggeredBlock);
		}

		void Awake() {
			_layerMask = LayerMask.GetMask(RaycastLayer);
		}

		void Update() {
			var hitCount = Physics.OverlapBoxNonAlloc(
				transform.position + Offset, Size, _hits, Quaternion.identity, _layerMask);
			var isTriggered = (hitCount > 0);
			UpdateState(isTriggered);
		}

		void UpdateState(bool isTriggered) {
			Triggered = isTriggered;
			TriggeredBlock.SetActive(isTriggered);
			NonTriggeredBlock.SetActive(!isTriggered);
		}

		void OnDrawGizmosSelected() {
			Gizmos.DrawCube(transform.position + Offset, Size * 2);
		}
	}
}
