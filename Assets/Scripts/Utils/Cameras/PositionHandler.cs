using UnityEngine;

namespace CityManager.Utils.Cameras {
	public sealed class PositionHandler : MonoBehaviour {
		[SerializeField] float Speed = 0.0f;

		void LateUpdate() {
			var z = Input.GetAxis("Vertical");
			var x = Input.GetAxis("Horizontal");
			var positionDelta = new Vector3(x, 0, z);
			transform.localPosition += Time.deltaTime * Speed * positionDelta;
		}
	}
}
