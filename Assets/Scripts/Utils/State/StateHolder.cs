#if UNITY_EDITOR
using UnityEditor;
using Newtonsoft.Json;
#endif

namespace CityManager.Utils.State {
	public abstract class StateHolder<THolder, TData> : InstancesHolder<StateHolder<THolder, TData>> where THolder : class {
		public THolder Self => this as THolder;
		public TData   Data;

		public virtual void Refresh() {}

		public virtual void Apply(TData data) {
			Data = data;
		}
		
	#if UNITY_EDITOR
		void OnDrawGizmosSelected() {
			var json = JsonConvert.SerializeObject(Data, Formatting.Indented);
			Handles.Label(transform.position, json);
		}
	#endif
	}
}
