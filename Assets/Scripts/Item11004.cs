using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item11004 : Item
{
    // Start is called before the first frame update
    public override void useItem()
    {
        UseMonkDiary4.instance.activeMonkDiary4(itemID);
    }
}
