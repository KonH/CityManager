using System.Collections.Generic;
using UnityEngine;

namespace CityManager.Utils.State {
	public abstract class StateHolder<T> : MonoBehaviour {
		public static HashSet<StateHolder<T>> Instances = new HashSet<StateHolder<T>>(); 
		
		public T State;

		public void OnEnable() {
			Instances.Add(this);
		}

		public void OnDisable() {
			Instances.Remove(this);
		}

		public abstract void Refresh();
		public abstract void Apply(T state);
	}
}
