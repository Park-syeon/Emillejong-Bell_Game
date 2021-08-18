using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAcquire : MonoBehaviour
{
    public int connectitemID;
    protected GameObject GIcon;

    private void Awake()
    {
        GIcon = GameObject.Find("GIcon");
    }
    private void Start()
    {
        GIcon.SetActive(false);
    }

    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        GIcon.SetActive(true);
        GIcon.transform.position = this.gameObject.transform.position;
        Debug.Log("hahahah");
        if (Input.GetKeyDown(KeyCode.G))
        {
            if(connectitemID == DatabaseManager.instance.GetCurrentItemID())
            {
                ItemEvents.instance.playItemEvent(connectitemID);
                Destroy(this.gameObject);
            }
            
        }
    }
    protected void OnTriggerExit2D(Collider2D collision)
    {
        GIcon.SetActive(true);
    }
}
