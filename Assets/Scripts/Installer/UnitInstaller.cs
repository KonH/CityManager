using UnityEngine;
using Zenject;
using CityManager.Unit;

namespace CityManager.Installer {
	[CreateAssetMenu(fileName = "UnitInstaller", menuName = "Installers/UnitInstaller")]
	public sealed class UnitInstaller : ScriptableObjectInstaller<UnitInstaller> {
		[SerializeField] UnitSetup UnitPrefab = null;

		public override void InstallBindings() {
			Container.BindFactory<UnitSetup, UnitSetup.Factory>().FromComponentInNewPrefab(UnitPrefab);
			Container.Bind(typeof(UnitManager), typeof(IInitializable)).To<UnitManager>().AsSingle();
		}
	}
}