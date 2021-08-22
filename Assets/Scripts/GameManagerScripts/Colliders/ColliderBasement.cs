using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderBasement : MonoBehaviour
{
    public static ColliderBasement instance;
    #region ΩÃ±€≈Ê
    private void Awake()    //ΩÃ±€≈Ê!!
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
