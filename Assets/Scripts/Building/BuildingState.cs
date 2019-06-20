using System;
using System.Collections.Generic;
using CityManager.Utils.State;

namespace CityManager.Building {
	public class BuildingState : StateHolder<BuildingState.Data> {
		[Serializable]
		public class Data {
			public string       Category;
			public string       Name;
			public int          Id;
			public Vec3Data     Position;
			public RotationData Rotation;
			public List<int>    Units;
		}

		public override void Refresh() {
			Instance.Category = GetComponent<BuildingCategory>().Name;
			Instance.Name     = GetComponent<BuildingSetup>().Name;

			var trans = transform;
			Instance.Position = new Vec3Data(trans.position);
			Instance.Rotation = new RotationData(trans.rotation);
		}

		public override void Apply(Data instance) {
			base.Apply(instance);
			var trans = transform;
			trans.position = instance.Position.ToVector3();
			trans.rotation = instance.Rotation.ToQuaternion();
		}
	}
}
