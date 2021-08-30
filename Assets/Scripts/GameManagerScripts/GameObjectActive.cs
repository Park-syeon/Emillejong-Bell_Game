using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectActive
{
    public void ActiveObjects(GameObject[] _A)
    {
        for(int i = 0; i < _A.Length; i++)
        {
            _A[i].gameObject.SetActive(true);
        }
    }
    public void InactiveObjects(GameObject[] _A)
    {
        for (int i = 0; i < _A.Length; i++)
        {
            _A[i].gameObject.SetActive(false);
        }
    }
}
