using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    private MovingObject thePlayer;
    private Inventory theInventory;
    private Bookshelf theBookshelf;

    void Start()
    {
        thePlayer = FindObjectOfType<MovingObject>();
        theInventory = FindObjectOfType<Inventory>();
        theBookshelf = FindObjectOfType<Bookshelf>();
    }

    // Update is called once per frame
    void Update()
    {
        if (theInventory.getActivated())
        {
            //thePlayer.setCanMove(false);
        }
        else if (theBookshelf.getActivated())
        {
            theInventory.setActivated(false);
            //thePlayer.setCanMove(false);
        }
        else
        {
            //thePlayer.setCanMove(true);
        }


    }
}
