using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderPond : MonoBehaviour
{
    public string mapname = "pond";
    public static ColliderPond instance;
    #region ?̱???
    private void Awake()    //?̱???!!
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
