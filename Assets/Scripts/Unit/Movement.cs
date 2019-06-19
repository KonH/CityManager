using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

namespace CityManager.Unit {
	public class Movement : MonoBehaviour {
		public NavMeshAgent Agent;
		public Transform    Target;
		
		void OnValidate() {
			Assert.IsNotNull(Agent);
		}

		void Start() {
			if ( Target ) {
				StartMoving(Target);
			}
		}

		public void StartMoving(Transform target) {
			Agent.destination = target.position;
		}

		void Update() {
			var isDone = (Agent.remainingDistance < Agent.stoppingDistance);
			enabled = !isDone;
		}
	}
}
