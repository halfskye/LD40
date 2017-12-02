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
        public int HouseAmountTotal = 15;
        public int HouseAmountSingle = 5;

        //Time to spawn
        public float waitForNext = 10;
        public float countDown = 10;

        //X Range
        public float xMin;
        public float xMax;

        //Y Range
        public float yMin;
        public float yMax;

        private Vector2 _pos;

        void Start()
        {
            _pos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
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
                countDown = waitForNext;
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
