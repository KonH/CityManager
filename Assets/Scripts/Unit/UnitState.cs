using System;
using CityManager.Utils.State;

namespace CityManager.Unit {
	public class UnitState : StateHolder<UnitState.Data> {
		[Serializable]
		public class Data {
			public int          Id;
			public Vec3Data     Position;
			public RotationData Rotation;
		}

		public override void Refresh() {
			var trans = transform;
			State.Position = new Vec3Data(trans.position);
			State.Rotation = new RotationData(trans.rotation);
		}

		public override void Apply(Data state) {
			base.Apply(state);
			var trans = transform;
			trans.position = state.Position.ToVector3();
			trans.rotation = state.Rotation.ToQuaternion();
		}
	}
}