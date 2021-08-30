using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartItem : MonoBehaviour
{
    public static StartItem instance;
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

    private void Start()
    {
        instance = this;
        Inventory.instance.GetAnItem(Constants.half_key1);
        Inventory.instance.GetAnItem(81008);
        Inventory.instance.GetAnItem(80006);

    }
}
