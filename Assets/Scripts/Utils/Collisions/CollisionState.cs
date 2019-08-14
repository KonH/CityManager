using UnityEngine;
using UnityEngine.Assertions;

namespace CityManager.Utils.Collisions {
	public sealed class CollisionState : MonoBehaviour {
		[SerializeField] string     RaycastLayer      = null;
		[SerializeField] Vector3    Size              = default;
		[SerializeField] Vector3    Offset            = default;
		[SerializeField] GameObject TriggeredBlock    = null;
		[SerializeField] GameObject NonTriggeredBlock = null;

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
