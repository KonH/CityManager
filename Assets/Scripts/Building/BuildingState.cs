using UnityEngine.Assertions;
using JetBrains.Annotations;
using CityManager.Utils.State;

namespace CityManager.Building {
	public class BuildingState : StateHolder<BuildingState, BuildingData> {
		public BuildingSetup Setup;

		void OnValidate() {
			Assert.IsNotNull(Setup);
		}

		public override void Refresh() {
			Data.Category = Setup.CategoryName;
			Data.Name     = Setup.BuildingName;

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
