using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAcquire : MonoBehaviour
{
    public int connectitemID;
    protected GameObject GIcon;
    private bool IsTriggerActivated;

    private void Awake()
    {
        GIcon = GameObject.Find("GIconParent").transform.Find("GIcon").gameObject;
    }
    private void Start()
    {
        GIcon.SetActive(false);
        IsTriggerActivated = false;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        GIcon.SetActive(true);
        GIcon.transform.position = this.gameObject.transform.position;
        IsTriggerActivated = true;
    }
    protected void OnTriggerExit2D(Collider2D collision)
    {
        GIcon.SetActive(false);
        IsTriggerActivated = false;
    }

    private void Update()
    {
        if (IsTriggerActivated)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                Do();
            }
        }
    }

    protected virtual void Do()
    {
        if (connectitemID == DatabaseManager.instance.GetCurrentItemID())
        {
            ItemEvents.instance.playItemEvent(connectitemID);
            Destroy(this.gameObject);
        }
    }
}
