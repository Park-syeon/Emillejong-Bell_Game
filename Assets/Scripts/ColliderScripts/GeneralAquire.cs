using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralAquire : ItemAcquire
{
    public int getItemID;
    protected override void Do()
    {
            Debug.Log("G��������");
            Inventory.instance.GetAnItem(getItemID);
    }
}
