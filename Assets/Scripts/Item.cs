using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]


public abstract class Item
{
    public int itemID;
    public string itemName;
    public string itemDescription;
    public int itemCount;
    public Sprite itemIcon;
    public Sprite itemPicture;
    public ItemType itemType;

    protected bool useItemActivated;


    public enum ItemType
    {
        monk_diary, //스님의 일기장
        monk_memo,  //스님의 쪽지
        child_memo, //동자승의 쪽지
        etc         //왕과의 편지, 반토막난 열쇠, 서재의 열쇠, 삽, 에밀레종제작문서들 등등
    }

    public Item() { } //default generator??

    public void GenerateItem(int _itemID, string _itemName, string _itemDescription, ItemType _itemType, int _itemCount = 1)
    {
        itemID = _itemID;
        itemName = _itemName;
        itemDescription = _itemDescription;
        itemType = _itemType;
        itemCount = _itemCount;
        itemIcon = Resources.Load("ItemIcon/" + _itemID.ToString(), typeof(Sprite)) as Sprite;
        itemPicture = Resources.Load("ItemPicture/" + _itemID.ToString(), typeof(Sprite)) as Sprite;
        useItemActivated = false;

    }

    //base 키워드는 뭔가요

    public abstract void useItem();

}


