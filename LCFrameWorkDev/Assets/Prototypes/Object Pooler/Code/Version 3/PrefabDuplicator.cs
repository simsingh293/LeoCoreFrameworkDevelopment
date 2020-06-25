using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Component Overview
/// <summary>
/// [Static class that duplicates a prefab and fills a referenced container]
/// </summary>
#endregion

public class PrefabDuplicator : MonoBehaviour
{
    #region Public Variables

    #endregion



    #region Private Variables

    #endregion





    #region Custom Methods

    public static void SingleObjectDuplication(GameObject prefab, int copies, ref List<GameObject> container)
    {
        for (int i = 0; i < copies; i++)
        {
            GameObject temp = Instantiate(prefab);

            temp.SetActive(false);

            container.Add(temp);
        }
    }


    #endregion
}
