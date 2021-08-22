using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTemple : MonoBehaviour
{
    public static ColliderTemple instance;
    #region �̱���
    private void Awake()    //�̱���!!
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }
    #endregion
}
