using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    static public OrderManager instance;
    #region ½Ì±ÛÅæ
    private void Awake()    //½Ì±ÛÅæ!!
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

    private MovingObject thePlayer;
    private Inventory theInventory;
    private Camera theCamera;


    public void setCanMove()
    {
        thePlayer.notMove = true;
    }

    public void Move()
    {
        thePlayer.notMove = false;
    }
    //setCanMove, Move ÇÔ¼ö ¸¸µé¾ú½À´Ï´Ù
    void Start()
    {
        thePlayer = FindObjectOfType<MovingObject>();
        theInventory = FindObjectOfType<Inventory>();
        theCamera = FindObjectOfType<Camera>();
    }

    public void moveOrNot()
    {
        if (DialogueManager.instance.talking)
        {
            theInventory.setActivated(false);
            theInventory.setStopKeyInput(true);
            thePlayer.notMove = true;
        }

        else if (theInventory.getActivated())
        {
            thePlayer.notMove = true;
        }

        else
        {
            theInventory.setStopKeyInput(false);
            thePlayer.notMove = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.G) || Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.KeypadEnter))
        {
            if (thePlayer.currentMapName != "MonkRoom")
                moveOrNot();
        }


    }
}
