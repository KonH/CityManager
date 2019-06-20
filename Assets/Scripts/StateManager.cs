using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using CityManager.Building;

namespace CityManager {
	public class StateManager {
		public class Data {
			public List<BuildingState.Data> Buildings = new List<BuildingState.Data>();
		}

		string SavePath {
			get { return Path.Combine(Application.persistentDataPath, "save.json"); }
		}

		public Data SaveData { get; private set; }
		
		public void Load() {
			if ( !File.Exists(SavePath) ) {
				return;
			}
			var input = File.ReadAllText(SavePath);
			Debug.Log("Loaded state: \n" + input);
			SaveData = JsonConvert.DeserializeObject<Data>(input);
		}

		public void Save() {
			var data = new Data();
			foreach ( var instance in BuildingState.Instances ) {
				instance.Refresh();
				data.Buildings.Add(instance.State);
			}
			var output = JsonConvert.SerializeObject(data, Formatting.Indented);
			Debug.Log("Saved state: \n" + output);
			File.WriteAllText(SavePath, output);
		}

		public void Delete() {
			if ( !File.Exists(SavePath) ) {
				return;
			}
			File.Delete(SavePath);
		}
	}
}