using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAcquire : MonoBehaviour
{
    public int connectitemID;

    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if(connectitemID == DatabaseManager.instance.GetCurrentItemID())
            {
                ItemEvents.instance.playItemEvent(connectitemID);
                Destroy(this.gameObject);
            }
            
        }
    }

}
