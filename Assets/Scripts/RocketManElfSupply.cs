using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketManElfSupply : MonoBehaviour {

	[SerializeField]
	private float _speed = 10;

	[SerializeField]
	private int _presentSupplyCount = 25;
	public int GetSupplyCount() {
		return _presentSupplyCount;
	}

	[SerializeField]
	private float _settleInTime = 2.0f;

	[SerializeField]
	private float _deliverSupplyTime = 2.0f;

	private Player _target = null;

	private enum States {
		SETTLE_IN = 0,
		TARGET_PLAYER = 1,
		DELIVER_SUPPLY = 2,
		JET_OFF = 3,
	};
	private States _state;

	private Rigidbody2D _rigidBody;

	private float _timer;

	private void Awake() {
		_rigidBody = this.GetComponent<Rigidbody2D>();

		StartSettleIn();
	}

	private void StartSettleIn() {
		_state = States.SETTLE_IN;

		_timer = _settleInTime;
	}

	private void StartTargetPlayer() {
		_state = States.TARGET_PLAYER;

		FindTarget();
	}

	private void StartDeliverSupply() {
		_state = States.DELIVER_SUPPLY;

		_timer = _deliverSupplyTime;
	}

	private void StartJetOff() {
		_state = States.JET_OFF;
	}

	private void Update() {
		switch(_state) {
			case States.SETTLE_IN: {
				UpdateSettleIn();
			}
			break;
			case States.TARGET_PLAYER: {
				UpdateTargetPlayer();
			}
			break;
			case States.DELIVER_SUPPLY: {
				UpdateDeliverSupply();
			}
			break;
			case States.JET_OFF: {
				UpdateJetOff();
			}
			break;
			default:
			break;
		}
	}

	private void UpdateSettleIn() {
		_timer -= Time.deltaTime;
		if(_timer < 0.0f) {
			StartTargetPlayer();
		}
	}

	private void UpdateTargetPlayer() {
		// _state = States.DELIVER_SUPPLY;
	}

	private void FindTarget() {
        //@TODO: Find Player
		_target = Player.Get();
		// Vector2 playerPos = _target.GetPos();
	}

	private void UpdateDeliverSupply() {
		_timer -= Time.deltaTime;
		if(_timer < 0.0f) {
			GivePresents();
			StartJetOff();
		}
	}

	private void GivePresents() {
		Player player = Player.Get();
		player.ReceivePresents(_presentSupplyCount);
	}

	private void UpdateJetOff() {
	}

	private void FixedUpdate() {
		switch(_state) {
			case States.SETTLE_IN: {
				FixedUpdateSettleIn();
			}
			break;
			case States.TARGET_PLAYER: {
				FixedUpdateTargetPlayer();
			}
			break;
			case States.DELIVER_SUPPLY: {
				FixedUpdateDeliverSupply();
			}
			break;
			case States.JET_OFF: {
				FixedUpdateJetOff();
			}
			break;
			default:
			break;
		}
	}

	private void FixedUpdateSettleIn() {
		Vector3 velocity = Vector3.down * 2.0f;
		_rigidBody.AddForce(velocity, ForceMode2D.Force);
	}

	private void FixedUpdateTargetPlayer() {
		Vector3 playerPos = _target.GetPos();
		Vector3 dirToPlayer = (playerPos - transform.position).normalized;

		Vector3 velocity = dirToPlayer * _speed;
		_rigidBody.AddForce(velocity, ForceMode2D.Force);
	}

	private void FixedUpdateDeliverSupply() {
		Vector3 playerPos = _target.GetPos();
		Vector3 dirToPlayer = (playerPos - transform.position).normalized;

		Vector3 velocity = dirToPlayer * 100.0f;
		// _rigidBody.velocity = dirToPlayer * 500.0f;
		_rigidBody.AddForce(velocity, ForceMode2D.Force);
	}

	private void FixedUpdateJetOff() {
		Vector3 velocity = Vector3.left * 30.0f;
		_rigidBody.AddForce(velocity, ForceMode2D.Force);
	}

	// private void OnCollisionEnter2D(Collision2D collision)
	// {
	// 		if(_state == States.TARGET_PLAYER) {
	// 			if (collision.gameObject.tag == "Player")
	// 			{
	// 					StartDeliverSupply();
	// 			}
	// 		}
	// }

	private void OnTriggerEnter2D(Collider2D collider) {
		if(_state == States.TARGET_PLAYER) {
			if (collider.gameObject.tag == "Player")
			{
					StartDeliverSupply();
			}
		}
	}

	private void OnBecameInvisible() {
		Destroy(this.gameObject);
	}
}
