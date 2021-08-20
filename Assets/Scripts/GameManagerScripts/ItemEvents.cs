using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEvents : MonoBehaviour
{
    public static ItemEvents instance;
    private void Awake()    //싱글톤!!
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


    private int itemID;
    public void playItemEvent(int _itemID)
    {
        itemID = _itemID;
        switch (itemID)
        {
            case Constants.rock:
                ItemRock();
                break;
            case Constants.previous_monkdiary1_ID:
                monkdiary1();
                break;
            case Constants.previous_monkdiary2_ID:
                monkdiary2();
                break;
            case Constants.brick:
                brick();
                break;
            case Constants.half_key1:
                halfKey();
                break;
            case Constants.half_key2:
                halfKey();
                break;
            case Constants.previous_realEmille:
                realEmille();
                break;
            case Constants.key34:
                key346577();
                break;
            case Constants.key65:
                key346577();
                break;
            case Constants.key77:
                key346577();
                break;
            default:
                Debug.LogError("올바르지 않은 콜라이더 할당 값이 있다 고쳐라");
                break;
        }
    }

    private void ItemRock()
    {
        Requirement.instance.Letcandleon(true);
    }
    private void monkdiary2()
    {
        if (Requirement.instance.GetIsCandleOn())
        {
            Inventory.instance.GetAnItem(Constants.real_monkdiary2_ID);
            Inventory.instance.RemoveAnItem(itemID);
        }
    }
    private void monkdiary1()
    {
        if (Requirement.instance.GetIsCandleOn())
        {
            Inventory.instance.GetAnItem(Constants.real_monkdiary1_ID);
            Inventory.instance.RemoveAnItem(itemID);
        }
    }
    private void brick()
    {
        Inventory.instance.GetAnItem(Constants.half_key2);
        Inventory.instance.RemoveAnItem(itemID);
    }
    private void key346577()
    {
        Requirement.instance.EmilleRoomUnlock(itemID);
        Inventory.instance.RemoveAnItem(itemID);
    }
    private void realEmille()
    {
        Inventory.instance.GetAnItem(Constants.real_realEmille);
        Inventory.instance.RemoveAnItem(itemID);
    }
    private void halfKey()
    {
        Requirement.instance.BasementUnlock(itemID);
        StoryFlow.instance.SetCanGetIntoBasement(Requirement.instance.IsBasementOpened());
        Inventory.instance.RemoveAnItem(itemID);
    }
}
