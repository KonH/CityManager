using System.IO;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using CityManager.Unit;
using CityManager.Building;
using CityManager.Utils.State;

namespace CityManager {
	public sealed class StateManager {
		string SavePath {
			get { return Path.Combine(Application.persistentDataPath, "save.json"); }
		}

		public StateData Data { get; private set; }

		public void Load() {
			if ( !File.Exists(SavePath) ) {
				Data = new StateData();
				return;
			}
			var input = File.ReadAllText(SavePath);
			Debug.Log("Loaded state: \n" + input);
			Data = JsonConvert.DeserializeObject<StateData>(input);
		}

		public void Save() {
			SaveData(Data.Units, UnitState.Instances);
			SaveData(Data.Buildings, BuildingState.Instances);
			var output = JsonConvert.SerializeObject(Data, Formatting.Indented);
			Debug.Log("Saved state: \n" + output);
			File.WriteAllText(SavePath, output);
		}

		public void Delete() {
			if ( !File.Exists(SavePath) ) {
				return;
			}
			File.Delete(SavePath);
		}

		void SaveData<TState, TData>(List<TData> container, HashSet<StateHolder<TState, TData>> instances) where TState : class {
			container.Clear();
			foreach ( var instance in instances ) {
				instance.Refresh();
				container.Add(instance.Data);
			}
		}
	}
}