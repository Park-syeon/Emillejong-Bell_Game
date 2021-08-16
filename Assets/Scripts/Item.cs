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
        monk_diary, //������ �ϱ���
        monk_memo,  //������ ����
        child_memo, //���ڽ��� ����
        etc         //�հ��� ����, ���丷�� ����, ������ ����, ��, ���з������۹����� ���
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

    //base Ű����� ������

    public abstract void useItem();

}


