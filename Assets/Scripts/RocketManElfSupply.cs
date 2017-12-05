using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketManElfSupply : MonoBehaviour {
	[SerializeField]
  private GameObject _starExploder = null;

	[SerializeField]
	private float _speedForSettleIn = 2.0f;
	[SerializeField]
	private float _speedToPlayer = 10.0f;
	[SerializeField]
	private float _speedForDelivery = 100.0f;
	[SerializeField]
	private float _speedForJetoff = 30.0f;

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

	private Vector3 _screenPos;

	private void Awake() {
		_rigidBody = this.GetComponent<Rigidbody2D>();

		StartSettleIn();
	}

	private void Start() {
		SoundController.Jetpack.Play();
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

		SoundController.Sparkle.Play();

		_timer = _deliverSupplyTime;
	}

	private void StartJetOff() {
		_state = States.JET_OFF;
	}

	private void Update() {
		_screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
		if(_screenPos.x <= 0.0f) {
			Destroy(this.gameObject);
		}

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
		StarExploder(Player.Get().GetPos());
		SoundController.DeliveredPayload.Play();
	}

    private void StarExploder(Vector3 pos)
    {
        GameObject explode = Instantiate(_starExploder);
        pos.x = pos.x - 1;
        pos.y = pos.y + 0.5f;
        explode.transform.position = pos;
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
		Vector3 velocity = Vector3.down * _speedForSettleIn;
		_rigidBody.AddForce(velocity, ForceMode2D.Force);
	}

	private void FixedUpdateTargetPlayer() {
		Vector3 playerPos = _target.GetPos();
		Vector3 dirToPlayer = (playerPos - transform.position).normalized;

		Vector3 velocity = dirToPlayer * _speedToPlayer;
		_rigidBody.AddForce(velocity, ForceMode2D.Force);
	}

	private void FixedUpdateDeliverSupply() {
		Vector3 playerPos = _target.GetPos();
		Vector3 dirToPlayer = (playerPos - transform.position).normalized;

		Vector3 velocity = dirToPlayer * _speedForDelivery;
		// _rigidBody.velocity = dirToPlayer * 500.0f;
		_rigidBody.AddForce(velocity, ForceMode2D.Force);
	}

	private void FixedUpdateJetOff() {
		Vector3 velocity = Vector3.left * _speedForJetoff;
		_rigidBody.AddForce(velocity, ForceMode2D.Force);
	}

	private void OnTriggerEnter2D(Collider2D collider) {
		if(_state == States.TARGET_PLAYER) {
			if (collider.gameObject.tag == "Player")
			{
					StartDeliverSupply();
			}
		}
	}

	private void OnDestroy() {
		SoundController.Jetpack.Stop();
	}

	// private void OnGUI() {
	// 	_screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
	// 	Rect rect = new Rect(50,50,100,100);
	// 	GUI.Label(rect, _screenPos.x.ToString());
	// }
}
