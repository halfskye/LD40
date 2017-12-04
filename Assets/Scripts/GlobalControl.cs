using UnityEngine;

namespace Assets.Scripts
{
    public class GlobalControl : MonoBehaviour
    {
        public static GlobalControl Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                DontDestroyOnLoad(gameObject);
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
