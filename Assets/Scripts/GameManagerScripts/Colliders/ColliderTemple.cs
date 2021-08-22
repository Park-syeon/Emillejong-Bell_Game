using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTemple : MonoBehaviour
{
    public string mapname = "temple";
    public static ColliderTemple instance;
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

    public void transferMapEvent(string name)
    {
        if (name == mapname)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
