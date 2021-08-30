using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEmilleRoom : MonoBehaviour
{
    public string mapname = "Á¾ ÀÖ´Â °÷";
    public static ColliderEmilleRoom instance;
    #region ½Ì±ÛÅæ
    private void Awake()    //½Ì±ÛÅæ!!
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
