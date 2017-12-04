using UnityEngine;

namespace Assets.Scripts
{
    public class PresentController : MonoBehaviour
    {
        static private PresentController _singleton = null;
        static public PresentController Get() { return _singleton; }

        [SerializeField]
        private GameObject _snowExploder = null;

        private void Awake()
        {
            _singleton = this;
        }

        public void SpawnExploder(Vector3 pos)
        {
            GameObject explode = Instantiate(_snowExploder);
            explode.transform.position = pos;
        }
    }
}
