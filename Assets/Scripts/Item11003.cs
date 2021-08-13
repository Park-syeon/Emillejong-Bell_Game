using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item11003 : Item
{
    public override void useItem()
    {
        UseMonkDiary3.instance.activeMonkDiary3(itemID);
    }
}
