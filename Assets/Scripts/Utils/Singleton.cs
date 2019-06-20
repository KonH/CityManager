using UnityEngine;
using UnityEngine.Assertions;

namespace CityManager.Utils {
	public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T> {
		public static T Instance { get; private set; }

		public void OnEnable() {
			Assert.IsNull(Instance);
			Instance = this as T;
		}

		public void OnDisable() {
			if ( Instance == this ) {
				Instance = null;
			}
		}
	}
}