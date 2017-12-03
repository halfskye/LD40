using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyManager : MonoBehaviour {

	[SerializeField]
	private GameObject _supplyPrefab = null;

	[SerializeField]
	private Transform _supplyStartPos = null;

	[SerializeField]
	private int _presentCountThreshold = 495;

	[SerializeField]
	private float _waitBetweenSupply = 5;
	private float _supplyTimer;

	private void Update() {
		//@TODO: Check if we need to spawn supply.
		if(NeedSupply()) {
			CreateSupply();
		}

		_supplyTimer -= Time.deltaTime;
	}

	private bool NeedSupply() {
		if(_supplyTimer < 0.0f) {
			Player player = Player.Get();
			int presentCount = player.GetPresents();
			return (presentCount < _presentCountThreshold);
		}

		return false;
	}

	private void CreateSupply() {
		//@TODO: Instantiate supply...
		GameObject go = Instantiate(_supplyPrefab, _supplyStartPos);

		// Reset supply timer;
		_supplyTimer = _waitBetweenSupply;
	}
}
