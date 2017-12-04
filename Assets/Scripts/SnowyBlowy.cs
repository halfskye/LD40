using UnityEngine;

namespace Assets.Scripts
{
    public class SnowyBlowy : MonoBehaviour
    {
        public float _delay = 0.1f;

        private void Start()
        {
            Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + _delay);
        }
    }
}
