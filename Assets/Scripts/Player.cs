using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	const int PRESENT_COUNT_START = 500;
	private int _presentCount = PRESENT_COUNT_START;
	public int GetPresents() {
		return _presentCount;
	}
	public void UsePresent() {
		_presentCount -= 1;
	}
	public void ReceivePresents(int amount) {
		_presentCount += amount;
	}

	private int _score = 0;
	public int GetScore() {
		return _score;
	}

	static private Player _singleton = null;

	private void Awake() {
		_singleton = this;
		_presentCount = PRESENT_COUNT_START;
		_score = 0;
	}

	static public Player Get() {
		return _singleton;
	}

	public Vector2 GetPos() {
		return transform.position;
	}

	public void PresentDelivered() {
		_score += 10;
	}

	public void OnGUI() {
		Rect rect = new Rect(0,0,50,50);
		GUIStyle guiStyle = GUIStyle.none;
		guiStyle.normal.textColor = Color.white;

		GUI.TextArea(rect, "PRESENTS: " + _presentCount, guiStyle);
		rect.y += 15;

		GUI.TextArea(rect, "SCORE: " + _score, guiStyle);
	}
}
