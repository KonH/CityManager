using System;
using CityManager.Utils.State;

namespace CityManager.Unit {
	public class UnitState : StateHolder<UnitState.Data> {
		[Serializable]
		public class Data {
			public int          Id;
			public int          HouseId;
			public Vec3Data     Position;
			public RotationData Rotation;
			public string       CurrentState;
		}

		public override void Refresh() {
			var trans = transform;
			Instance.Position = new Vec3Data(trans.position);
			Instance.Rotation = new RotationData(trans.rotation);

			var stateMachine = GetComponent<UnitStateMachine>();
			Instance.CurrentState = stateMachine.CurrentState.GetType().FullName;
		}

		public override void Apply(Data instance) {
			base.Apply(instance);
			var trans = transform;
			trans.position = instance.Position.ToVector3();
			trans.rotation = instance.Rotation.ToQuaternion();

			var stateMachine = GetComponent<UnitStateMachine>();
			stateMachine.StartState(instance.CurrentState);
		}
	}
}