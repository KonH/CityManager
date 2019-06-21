using UnityEngine.Assertions;
using JetBrains.Annotations;
using CityManager.Utils.State;

namespace CityManager.Unit {
	public class UnitState : StateHolder<UnitState, UnitData> {
		public UnitSetup Setup;

		void OnValidate() {
			Assert.IsNotNull(Setup);
		}

		public override void Refresh() {
			var trans = transform;
			Data.Position = new Vec3Data(trans.position);
			Data.Rotation = new RotationData(trans.rotation);

			Data.CurrentState = Setup.StateMachine.CurrentState.GetType().FullName;
		}

		public override void Apply(UnitData instance) {
			base.Apply(instance);
			var trans = transform;
			trans.position = instance.Position.ToVector3();
			trans.rotation = instance.Rotation.ToQuaternion();

			Setup.StateMachine.StartState(instance.CurrentState);
		}
		
		[CanBeNull]
		public static UnitSetup TryGetNonWorkingUnit() {
			foreach ( var instance in UnitState.Instances ) {
				if ( instance.Data.WorkPlaceId > 0 ) {
					continue;
				}
				return instance.Self.Setup;
			}
			return null;
		}
	}
}