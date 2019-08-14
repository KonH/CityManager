using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

namespace CityManager.Unit {
	public sealed class Movement : MonoBehaviour {
		public NavMeshAgent Agent;

		Action _callback;

		void OnValidate() {
			Assert.IsNotNull(Agent);
		}

		public void StartMoving(Transform target, Action callback) {
			Agent.destination = target.position;
			_callback         = callback;
			enabled = true;
		}

		void Update() {
			var isDone = (Agent.remainingDistance < Agent.stoppingDistance);
			if ( isDone ) {
				enabled = false;
				_callback();
			}
		}
	}
}
