using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField]
	private int PRESENT_COUNT_START = 100;
	private int _presentCount;
	public int GetPresents() {
		return _presentCount;
	}
	public bool HasPresents() {
		return (_presentCount > 0);
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

    [SerializeField]
    private TextMesh _presentGui = null;
    [SerializeField]
    private TextMesh _scoreGui = null;

	private Rigidbody2D _rigidBody = null;

	static private Player _singleton = null;

	private void Awake() {
		_singleton = this;
		_rigidBody = this.GetComponent<Rigidbody2D>();
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

	private void FixedUpdate() {
		UpdateMassOnPresents();
	}

	private void UpdateMassOnPresents() {
		float presentMassNumerator = Mathf.Max(_presentCount, PRESENT_COUNT_START);
		float newMass = (presentMassNumerator / (float)(PRESENT_COUNT_START));
		_rigidBody.mass = newMass;
	}

	public void OnGUI() {

        _presentGui.text = _presentCount.ToString();
        _scoreGui.text = _score.ToString();
	}
}
