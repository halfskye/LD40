using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class GotoTitleScene : MonoBehaviour
    {
        private void Update()
        {
            StartCoroutine(LoadNextLevel(3f, "TitleScene"));
        }

        IEnumerator LoadNextLevel(float delay, string level)
        {
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene(level);
        }
    }
}
