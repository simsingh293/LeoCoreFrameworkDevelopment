using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LeoCore
{

    [System.Serializable]
    public class Pool_V1
    {
        public string name;
        public GameObject prefab;
        public int copies;
        public Transform parent;
    }


    #region Component Overview
    /// <summary>
    /// Create an Object Pool based on a predefined struct
    /// </summary>
    #endregion


    public class Pooler_V1 : MonoBehaviour
    {
        #region Public Variables

        public List<Pool_V1> pools = new List<Pool_V1>();



        // Test spawning capability
        public bool Spawn = false;

        #endregion



        #region Private Variables
        private Dictionary<string, Queue<GameObject>> poolDictionary = null;

        #endregion



        #region MonoBehaviour Methods
        private void Start()
        {
            poolDictionary = new Dictionary<string, Queue<GameObject>>();

            GeneratePool();
        }


        private void Update()
        {
            if (Spawn)
            {
                SpawnObjectFromPool(pools[0].name);
                Spawn = false;
            }
        }

        private void FixedUpdate()
        {

        }
        #endregion



        #region Custom Methods

        void GeneratePool()
        {

            foreach(var pool in pools)
            {
                Queue<GameObject> tempQueue = new Queue<GameObject>();

                for (int i = 0; i < pool.copies; i++)
                {
                    GameObject temp = Instantiate(pool.prefab);

                    temp.transform.parent = pool.parent;

                    temp.SetActive(false);

                    tempQueue.Enqueue(temp);
                }

                poolDictionary.Add(pool.name, tempQueue);
            }
        }

        public GameObject SpawnObjectFromPool(string poolName)
        {
            if (poolDictionary.ContainsKey(poolName))
            {
                GameObject result = null;

                for (int i = 0; i < poolDictionary[poolName].Count; i++)
                {
                    result = poolDictionary[poolName].Dequeue();


                    if (result.activeSelf)
                    {
                        poolDictionary[poolName].Enqueue(result);

                        result = null;
                        continue;
                    }
                    else
                    {
                        result.SetActive(true);

                        poolDictionary[poolName].Enqueue(result);

                        break;
                    }
                }

                return result;
            }

            else
            {
                return null;

            }
        }

        #endregion
    }
}