using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setActiveDiary4 : MonoBehaviour
{
    public static setActiveDiary4 instance;
    #region //ΩÃ±€≈Ê
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
    public GameObject[] activeobjects;

    public void active()
    {
        for(int i = 0; i < activeobjects.Length; i++)
        {
            activeobjects[i].SetActive(true);
        }
    }
    private void Start()
    {
        if (Inventory.instance.FindItem(Constants.real_monkdiary3_ID))
        {
            active();
        }
        else
        {
            for (int i = 0; i < activeobjects.Length; i++)
            {
                activeobjects[i].SetActive(false);
            }
        }
    }

}
