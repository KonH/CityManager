using System;
using CityManager.Utils;
using JetBrains.Annotations;
using CityManager.Utils.State;

namespace CityManager.Building {
	public sealed class BuildingState : StateHolder<BuildingState, BuildingData> {
		public string CategoryName;
		public string BuildingName;

		[NonSerialized]
		public BuildingSetup Owner;

		void OnValidate() {
			AssertExt.IsNotNullOrWhiteSpace(CategoryName);
			AssertExt.IsNotNullOrWhiteSpace(BuildingName);
		}

		public override void Refresh() {
			Data.Category = CategoryName;
			Data.Name     = BuildingName;

			var trans = transform;
			Data.Position = new Vec3Data(trans.position);
			Data.Rotation = new RotationData(trans.rotation);
		}

		public override void Apply(BuildingData data) {
			base.Apply(data);
			var trans = transform;
			trans.position = data.Position.ToVector3();
			trans.rotation = data.Rotation.ToQuaternion();
		}

		[CanBeNull]
		public static BuildingState FindStateById(int id) {
			foreach ( var instance in Instances ) {
				var data = instance.Data;
				if ( data.Id == id ) {
					return instance.Self;
				}
			}
			return null;
		}
	}
}
