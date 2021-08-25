using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralAquire : ItemAcquire
{
    public int getItemID;
    public GameObject A;
    protected override void Do()
    {
            Debug.Log("G¸¦´­·¶´Ù");
            Inventory.instance.GetAnItem(getItemID);
            Destroy(this.gameObject);
            Destroy(A);
    }
}
