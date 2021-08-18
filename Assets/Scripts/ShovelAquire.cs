using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelAquire : ItemAcquire
{
    public int getItemID;

    protected override void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (connectitemID == DatabaseManager.instance.GetCurrentItemID())
            {
                Inventory.instance.GetAnItem(getItemID);
                Destroy(this.gameObject);
            }

        }
    }
}
