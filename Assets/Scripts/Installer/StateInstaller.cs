using Zenject;

namespace CityManager.Installer {
	public sealed class StateInstaller : MonoInstaller<StateInstaller> {
		public override void InstallBindings() {
			var stateManager = new StateManager();
			Container.BindInstance(stateManager).AsSingle();
			stateManager.Load();
		}
	}
}