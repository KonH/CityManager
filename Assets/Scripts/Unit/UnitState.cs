using System;
using JetBrains.Annotations;
using CityManager.Utils.State;

namespace CityManager.Unit {
	public sealed class UnitState : StateHolder<UnitState, UnitData> {
		[NonSerialized]
		public UnitSetup Owner;

		public override void Refresh() {
			var trans = transform;
			Data.Position = new Vec3Data(trans.position);
			Data.Rotation = new RotationData(trans.rotation);

			var curState = Owner.StateMachine.CurrentState;
			Data.CurrentState  = curState.GetType().FullName;
			Data.StateProgress = curState.Progress;
		}

		public override void Apply(UnitData instance) {
			base.Apply(instance);
			var trans = transform;
			trans.position = instance.Position.ToVector3();
			trans.rotation = instance.Rotation.ToQuaternion();

			Owner.StateMachine.StartState(instance.CurrentState, instance.StateProgress);
		}

		[CanBeNull]
		public static UnitSetup TryGetNonWorkingUnit() {
			foreach ( var instance in Instances ) {
				if ( instance.Data.WorkPlaceId > 0 ) {
					continue;
				}
				return instance.Self.Owner;
			}
			return null;
		}
	}
}