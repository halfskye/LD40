using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class PresentController : MonoBehaviour
    {
        static private PresentController _singleton = null;
        static public PresentController Get() { return _singleton; }

        [SerializeField]
        private GameObject _snowExploder = null;
        [SerializeField]
        private GameObject _presentExploder = null;

        private void Awake()
        {
            _singleton = this;
        }

        public void SpawnExploder(Vector3 pos)
        {
            GameObject explode = Instantiate(_snowExploder);
            explode.transform.position = pos;
        }

        public void ChimneyExploder(Vector3 pos)
        {
            GameObject explode = Instantiate(_presentExploder);
            explode.transform.position = pos;
        }

        IEnumerator DestroyExplode(float delay, GameObject obj)
        {
            yield return new WaitForSeconds(delay);
            Destroy(obj);
        }
    }
}
