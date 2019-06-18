using UnityEngine;

namespace CityManager.Utils.Cameras {
	public class DistanceHandler : MonoBehaviour {
		public float Speed;

		void LateUpdate() {
			var axis = Input.GetAxis("Mouse ScrollWheel");
			transform.localPosition += axis * Speed * Time.deltaTime * Vector3.forward;
		}
	}
}
