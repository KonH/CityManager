using UnityEngine;
using Zenject;
using CityManager.Unit;

namespace CityManager.Installer {
	[CreateAssetMenu(fileName = "UnitInstaller", menuName = "Installers/UnitInstaller")]
	public class UnitInstaller : ScriptableObjectInstaller<UnitInstaller> {
		public UnitSetup UnitPrefab;

		public override void InstallBindings() {
			Container.BindFactory<UnitSetup, UnitSetup.Factory>().FromComponentInNewPrefab(UnitPrefab);
			Container.Bind(typeof(UnitManager), typeof(IInitializable)).To<UnitManager>().AsSingle();
		}
	}
}