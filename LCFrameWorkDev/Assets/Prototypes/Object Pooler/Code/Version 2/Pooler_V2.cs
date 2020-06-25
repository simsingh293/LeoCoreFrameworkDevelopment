using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Component Overview
/// <summary>
/// [Use created Pools(V2) settings to generate object pools]
/// </summary>
#endregion

public class Pooler_V2 : MonoBehaviour
{
    #region Public Variables
    public List<Pool_V2> pools = new List<Pool_V2>();
    public bool spawn = false;

    #endregion



    #region Private Variables

    Dictionary<string, Queue<GameObject>> poolDictionary = new Dictionary<string, Queue<GameObject>>();

    #endregion



    #region MonoBehaviour Methods
    private void Start()
    {
        if(pools.Count > 0)
        {
            GeneratePools();
        }
    }

        
    private void Update()
    {
        if (spawn)
        {
            SpawnObjectFromPool(pools[0].NameOfPool);
            spawn = false;
        }
    }

    private void FixedUpdate()
    {
            
    }
    #endregion



    #region Custom Methods

    void GeneratePools()
    {
        foreach (var pool in pools)
        {
            Queue<GameObject> tempQueue = new Queue<GameObject>();

            for (int i = 0; i < pool.NumberOfCopies; i++)
            {
                GameObject temp = Instantiate(pool.Prefab);

                temp.SetActive(false);

                temp.transform.parent = this.transform;

                tempQueue.Enqueue(temp);

                
            }

            poolDictionary.Add(pool.NameOfPool, tempQueue);
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
