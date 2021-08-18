using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralAquire : ItemAcquire
{
    public int getItemID;
    protected override void OnTriggerStay2D(Collider2D collision)
    {
        GIcon.SetActive(true);
        GIcon.transform.position = this.gameObject.transform.position;
        if (Input.GetKeyDown(KeyCode.G))
        {
            Inventory.instance.GetAnItem(getItemID);
        }
    }
}
