using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class RestartButton : MonoBehaviour
    {
        [SerializeField]
        private TextMesh _score;

        private bool _keyRestart() { return (Input.GetKeyDown(KeyCode.Return)); }

        private void Start()
        {
            _score.text = Player.Get().GetScore().ToString();
        }

        private void Update()
        {
            if (_keyRestart())
            {
                SceneManager.LoadScene("TS");
            }
        }
    }
}
