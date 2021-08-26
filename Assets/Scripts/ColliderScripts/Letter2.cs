using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter2 :ItemAcquire
{
    public int getItemID;
    public GameObject A;
    protected override void Do()
    {
        if (Inventory.instance.FindItem(Constants.letter1))
        {
            SeveralDialogue.instance.Letter2();
            Inventory.instance.GetAnItem(getItemID);
        }
        else if (Inventory.instance.FindItem(Constants.letter2))
        {
            SeveralDialogue.instance.AfterLetter2();
        }
        else
        {
            SeveralDialogue.instance.yetLetter2();
        }
    }
}
