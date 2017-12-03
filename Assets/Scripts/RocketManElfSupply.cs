using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketManElfSupply : MonoBehaviour {

	[SerializeField]
	private float _speed = 10;

	private Player _target = null;

	private enum States {
		SETTLE = 0,
		TARGET_PLAYER = 1,
		DELIVER_SUPPLY = 2,
		JET_OFF = 3,
	};

	private void Awake() {
		FindTarget();
	}

	private void FindTarget() {
		//@TODO: Find Player
		_target = Player.Get();
		// Vector2 playerPos = _target.GetPos();
	}

	private void FixedUpdate() {
		Vector3 playerPos = _target.GetPos();
		Vector3 dirToPlayer = playerPos - transform.position;

		Rigidbody2D rigidbody = this.GetComponent<Rigidbody2D>();
		Vector3 velocity = dirToPlayer * _speed;
		rigidbody.AddForce(dirToPlayer, ForceMode2D.Force);
	}

	private void OnBecameInvisible() {
		Destroy(this.gameObject);
	}
}
