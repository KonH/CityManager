using System;
using CityManager.Utils.State;

namespace CityManager.Building {
	public class BuildingState : StateHolder<BuildingState.Data> {
		[Serializable]
		public class Data {
			public string       Category;
			public string       Name;
			public Vec3Data     Position;
			public RotationData Rotation;
		}

		public override void Refresh() {
			State.Category = GetComponent<BuildingCategory>().Name;
			State.Name     = GetComponent<BuildingSetup>().Name;

			var trans = transform;
			State.Position = new Vec3Data(trans.position);
			State.Rotation = new RotationData(trans.rotation);
		}

		public override void Apply(Data state) {
			var trans = transform;
			trans.position = state.Position.ToVector3();
			trans.rotation = state.Rotation.ToQuaternion();
		}
	}
}
