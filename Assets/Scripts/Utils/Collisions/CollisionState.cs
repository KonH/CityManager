﻿using UnityEngine;
using UnityEngine.Assertions;

namespace CityManager.Utils.Collisions {
	public class CollisionState : MonoBehaviour {
		public float      Size;
		public string     RaycastLayer;
		public GameObject TriggeredBlock;
		public GameObject NonTriggeredBlock;
		
		public bool Triggered { get; private set; }

		int        _layerMask = 0;
		Collider[] _hits      = new Collider[4];

		void OnValidate() {
			Assert.IsNotNull(TriggeredBlock);
			Assert.IsNotNull(NonTriggeredBlock);
		}

		void Awake() {
			_layerMask = LayerMask.GetMask(RaycastLayer);
		}

		void Update() {
			var hitCount = Physics.OverlapBoxNonAlloc(
				transform.position, Vector3.one * Size, _hits, Quaternion.identity, _layerMask);
			var isTriggered = (hitCount > 0);
			UpdateState(isTriggered);
		}

		void UpdateState(bool isTriggered) {
			Triggered = isTriggered;
			TriggeredBlock.SetActive(isTriggered);
			NonTriggeredBlock.SetActive(!isTriggered);
		}

		void OnDrawGizmosSelected() {
			Gizmos.DrawCube(transform.position, Size * 2 * Vector3.one);
		}
	}
}