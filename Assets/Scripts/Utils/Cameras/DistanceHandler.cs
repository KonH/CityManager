using UnityEngine;

namespace CityManager.Utils.Cameras {
	public sealed class DistanceHandler : MonoBehaviour {
		[SerializeField] float Speed = 0.0f;

		void LateUpdate() {
			var axis = Input.GetAxis("Mouse ScrollWheel");
			transform.localPosition += axis * Speed * Time.deltaTime * Vector3.forward;
		}
	}
}
