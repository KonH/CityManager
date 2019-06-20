using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using CityManager.Unit;
using CityManager.Building;

namespace CityManager {
	public class StateManager {
		public class Data {
			public UnitData                 UnitData     = new UnitData();
			public List<UnitState.Data>     Units        = new List<UnitState.Data>();
			public BuildingData             BuildingData = new BuildingData();
			public List<BuildingState.Data> Buildings    = new List<BuildingState.Data>();
		}

		string SavePath {
			get { return Path.Combine(Application.persistentDataPath, "save.json"); }
		}

		public Data SaveData { get; private set; }
		
		public void Load() {
			if ( !File.Exists(SavePath) ) {
				SaveData = new Data();
				return;
			}
			var input = File.ReadAllText(SavePath);
			Debug.Log("Loaded state: \n" + input);
			SaveData = JsonConvert.DeserializeObject<Data>(input);
		}

		public void Save() {
			SaveUnits();
			SaveBuildings();
			var output = JsonConvert.SerializeObject(SaveData, Formatting.Indented);
			Debug.Log("Saved state: \n" + output);
			File.WriteAllText(SavePath, output);
		}

		void SaveUnits() {
			SaveData.Units.Clear();
			foreach ( var instance in UnitState.Instances ) {
				instance.Refresh();
				SaveData.Units.Add(instance.State);
			}
		}
		
		void SaveBuildings() {
			SaveData.Buildings.Clear();
			foreach ( var instance in BuildingState.Instances ) {
				instance.Refresh();
				SaveData.Buildings.Add(instance.State);
			}
		}
		
		public void Delete() {
			if ( !File.Exists(SavePath) ) {
				return;
			}
			File.Delete(SavePath);
		}
	}
}