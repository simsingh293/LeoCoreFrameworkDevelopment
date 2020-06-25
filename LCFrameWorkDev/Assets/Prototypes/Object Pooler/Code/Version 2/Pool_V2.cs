using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Component Overview
/// <summary>
/// [A Scriptable Object Pool class]
/// </summary>
#endregion

[System.Serializable]
[CreateAssetMenu(fileName = "New Pool", menuName = "Object Pooling/New Pool", order = 0)]
public class Pool_V2 : ScriptableObject
{
    #region Public Variables

    //public string nameOfPool;
    public string NameOfPool
    {
        get { return poolName; }
        //set { poolName = value; }
    }

    //public int numberOfCopies;
    public int NumberOfCopies
    {
        get { return copies; }
        //set { copies = value; }
    }

    //public GameObject prefab = null;
    public GameObject Prefab
    {
        get { return original; }
        //set { prefab = value; }
    }


    #endregion



    #region Private Variables

    [SerializeField] private string poolName = "";
    [SerializeField] private int copies = 0;
    [SerializeField] private GameObject original = null;
    #endregion



    #region Custom Methods

    #endregion
}
