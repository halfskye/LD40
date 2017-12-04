﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyManager : MonoBehaviour {

	[SerializeField]
	private GameObject _supplyPrefab = null;

	[SerializeField]
	private Transform _supplyStartPos = null;

	[SerializeField]
	private float _presentCountThresholdPct = 95.0f;

	[SerializeField]
	private float _waitBetweenSupply = 5;
	private float _supplyTimer;

	private int _targetPresentTresholdForResupply;

	private void Start() {
		Player player = Player.Get();
		int presentCount = player.GetPresents();
		SetNewResupplyThreshold(presentCount);
	}

	private void SetNewResupplyThreshold(int presentCount) {
		_targetPresentTresholdForResupply = (int)(presentCount * (_presentCountThresholdPct/100.0f));
	}

	private void Update() {
		_supplyTimer -= Time.deltaTime;

		//@TODO: Check if we need to spawn supply.
		if(NeedSupply()) {
			CreateSupply();
		}
	}

	private bool NeedSupply() {
		if(_supplyTimer < 0.0f) {
			Player player = Player.Get();
			int presentCount = player.GetPresents();
			return (presentCount <= _targetPresentTresholdForResupply);
		}

		return false;
	}

	private void CreateSupply() {
		//@TODO: Instantiate supply...
		GameObject go = Instantiate(_supplyPrefab, _supplyStartPos);
		RocketManElfSupply supply = go.GetComponent<RocketManElfSupply>();
		int supplyCount = supply.GetSupplyCount();
		Player player = Player.Get();
		int presentCount = player.GetPresents();
		int expectedNewCount = presentCount + supplyCount;
		SetNewResupplyThreshold(expectedNewCount);

		// Reset supply timer;
		_supplyTimer = _waitBetweenSupply;
	}
}
