using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class SnowRando : MonoBehaviour
    {
        //Collect Houses
        public GameObject[] Snows;

        //Object Pooling
        private List<GameObject> _snowPool;
        public int SnowAmountTotal;
        public int SnowAmountSingle;

        //Time to spawn
        public float waitForNextMax;
        public float countDown;

        //X Range
        public float xMin;
        public float xMax;

        //Y Range
        public float yMin;
        public float yMax;

        [SerializeField]
        private float _snowSpeed = 3.0f;
        public float GetSnowSpeed() {
          return _snowSpeed;
        }

        static private SnowRando _singleton = null;
        static public SnowRando Get() {
          return _singleton;
        }

        private void Awake() {
          _singleton = this;
        }

        void Start()
        {
            _snowPool = new List<GameObject>();
            foreach (var snow in Snows)
            {
                for (int j = 0; j < SnowAmountSingle; j++)
                {
                    GameObject obj = Instantiate(snow);
                    obj.SetActive(false);
                    _snowPool.Add(obj);
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            countDown -= Time.deltaTime;
            if (countDown <= 0)
            {
                SpawnSnow();
                countDown = waitForNextMax;
            }
        }

        void SpawnSnow()
        {
            if (_snowPool != null)
            {
                GameObject gameObj = _snowPool[Random.Range(0, _snowPool.Count)];
                if (!gameObj.activeInHierarchy)
                {
                    gameObj.transform.position = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
                    gameObj.SetActive(true);
                }
            }
            else
            {
                Debug.Log("Add Houses to the HouseRando Script you DumbAss!!!!");
            }
        }
    }
}
