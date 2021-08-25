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
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
