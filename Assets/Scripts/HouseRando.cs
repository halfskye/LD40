using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class HouseRando : MonoBehaviour
    {
        //Collect Houses
        public GameObject[] Houses;

        //Object Pooling
        private List<GameObject> _housePool;
        public int HouseAmountTotal;
        public int HouseAmountSingle;

        //Time to spawn
        public float waitForNextMax;
        public float countDown;

        //X Range
        public float xMin;
        public float xMax;

        //Y Range
        public float yMin;
        public float yMax;

        private Vector3 _pos;

        [SerializeField]
        private float _houseSpeed = 3.0f;
        public float GetHouseSpeed() {
          return _houseSpeed;
        }

        static private HouseRando _singleton = null;
        static public HouseRando Get() {
          return _singleton;
        }

        private void Awake() {
          _singleton = this;
        }

        void Start()
        {
            _pos = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), transform.position.z);
            _housePool = new List<GameObject>();
            foreach (var house in Houses)
            {
                for (int j = 0; j < HouseAmountSingle; j++)
                {
                    GameObject obj = Instantiate(house, _pos, transform.rotation);
                    obj.SetActive(false);
                    _housePool.Add(obj);
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            countDown -= Time.deltaTime;
            if (countDown <= 0)
            {
                SpawnHouse();
                countDown = Random.Range(1, waitForNextMax);
            }
        }

        void SpawnHouse()
        {
            if (_housePool != null)
            {
                GameObject gameObj = _housePool[Random.Range(0, _housePool.Count)];
                if (!gameObj.activeInHierarchy)
                {
                    gameObj.transform.position = _pos;
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
