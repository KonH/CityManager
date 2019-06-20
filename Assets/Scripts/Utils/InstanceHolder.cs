using System.Collections.Generic;
using UnityEngine;

namespace CityManager.Utils {
	public abstract class InstancesHolder<T> : MonoBehaviour where T : InstancesHolder<T> {
		public static HashSet<T> Instances = new HashSet<T>();

		public virtual void OnEnable() {
			Instances.Add(this as T);
		}

		public virtual void OnDisable() {
			Instances.Remove(this as T);
		}
	}
}
