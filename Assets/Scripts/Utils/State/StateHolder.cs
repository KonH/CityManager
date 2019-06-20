namespace CityManager.Utils.State {
	public abstract class StateHolder<THolder, TData> : InstancesHolder<StateHolder<THolder, TData>> where THolder : class {
		public THolder Self => this as THolder;
		public TData   Data;

		public virtual void Refresh() {}

		public virtual void Apply(TData data) {
			Data = data;
		}
	}
}
