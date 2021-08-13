using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager instance;

    private void Awake()    //�̱���!!
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        List<Dictionary<string, object>> data = CSVReader.Read("itemdatabase");


        //��� �� awake�� �־���ϳ�
        for (var i = 0; i < data.Count; i++)
        {
            int a = (int) data[i]["ItemID"];
            Item.ItemType typeTemp;
            if(data[i]["ItemType"].ToString()== "monk_diary")
            {
                typeTemp = Item.ItemType.monk_diary;
            }
            else if (data[i]["ItemType"].ToString() == "monk_memo")
            {
                typeTemp = Item.ItemType.monk_memo;
            }
            else if (data[i]["ItemType"].ToString() == "child_memo")
            {
                typeTemp = Item.ItemType.child_memo;
            }
            else
            {
                typeTemp = Item.ItemType.etc;
            }


            if (a == Constants.previous_monkdiary3_ID)
            {
                Item temp = new Item11003();
                temp.GenerateItem(a, data[i]["ItemName"].ToString(), data[i]["ItemDescription"].ToString(), typeTemp);
                itemList.Add(temp);
            }
            else if (a == Constants.previous_monkdiary4_ID)
            {
                Item temp = new Item11004();
                temp.GenerateItem(a, data[i]["ItemName"].ToString(), data[i]["ItemDescription"].ToString(), typeTemp);
                itemList.Add(temp);
            }
            else
            {
                Item temp = new GeneralItem();
                temp.GenerateItem(a, data[i]["ItemName"].ToString(), data[i]["ItemDescription"].ToString(), typeTemp);
                itemList.Add(temp);
            }
        }

        currentItemID = 0;
    }

    public string[] var_name;
    public float[] var;
    public Item item;
    private int currentItemID;
    private int[] EmilleRoom = new int[3] { 9,9,9 };    //0�̸� �����Ȱ�, 0�� �ƴϸ� ����
    private int[] Basement = new int[2] { 9, 9 }; //0�̸� �����Ȱ�, 0�� �ƴϸ� ����
    private bool IsCandleOn = false;
    private bool IsRealEmille = false;  //�̰� �� �ִ��� �𸣰���


    public string[] switch_name;
    public bool[] switches;

    public List<Item> itemList = new List<Item>();

    // Start is called before the first frame update
    void Start()
    {
        /*
        ������ ���̵�(ItemID)
        ������ �ϱ��� #1 ��� ��  : 11001
        ������ �ϱ��� #3 ��� ��  : 11003
        ������ �ϱ��� #4 ��� ��  : 11004
        ������ �ϱ��� #1 ~ #4     : 10001, 10002, 10003, 10004
        ������ �޸� #1 ~ #5       : 20001 ~ 20005
        ���ڽ��� �޸� #1 ~ #8     : 30001 ~ 30008
        ���԰� �հ��� ���� #1, #2 : 40001, 40002
        ��¥ ���з��� ���� ����   : 50001
        ��¥ ���з��� ���� ����   : 60001
        ���Ͻ��� ������ ��¥ �ϱ��� : 70001
        ��Ÿ ������
            1. ���丷�� ����#1    : 80001
            2. ���丷�� ����#2    : 80002
            3. ��                 : 80003
            4. �ν˵�             : 80004      //�ν˵��� �ϱ���1�� �б� ���� ���ʿ� ���� ���̴� ����
            5. �ص�å             : 80005
            6. ������ �����      : 90001, 90002, 90005, 90012, 90024, 90034(*), 90055, 90056, 90059, 90061, 90065(*), 90074, 90077(*), 90081, 90088, 90092, 90095, 90100

         */
        /*
                itemList.Add(new GeneralItem(11001, "������ �ϱ��� #1", "������ �ϱ���. �ƹ��͵� ������ �ʴ´�. ���𰡿� ����ؾ��� �� ����.", Item.ItemType.monk_diary));
                itemList.Add(new Item(11003, "������ �ϱ��� #3", "������ �ϱ���. �� �� ���� ���� �����ִ�. �ص��ؾ� �� �� ����.", Item.ItemType.monk_diary));
                itemList.Add(new Item(11004, "������ �ϱ��� #4", "������ �ϱ���. ������ ������� ����� �� �� ����.", Item.ItemType.monk_diary));
                itemList.Add(new Item(10001, "������ �ϱ��� #1", "������ �ϱ���. \n \"���ϲ��� ������ ������ �˸��� ���� ���� ����� �ϼ̴�.�׷��� ���ֹ��� ���� ���� ���� ����������� �ұ��ϰ� ���� �Ҹ��� �︮�� �ʰ� �ִ�.�̰� ���� �� ���ϱ� ? �� �̻� ���� �ٽ� ���� ������ ���� �ʴ´�.�鼺�鿡�� ���� ���ֹ����͵� ���Ǹ�, ���ϲ����� �鼺�鿡�� ���ָ� �� ������ �ϽŴ�.������ � ������ ���� �鷶���� ������ ���� ���� �ִ� ���� �� ���̻��̶� �Ѵ�..�ᱹ �� �������� ���ָ� ���� �ʰ� ���ƿԴ�.������..���õ� ���ó� ���� �Ҹ��� �︮�� �ʾҴ�.\"", Item.ItemType.monk_diary));
                itemList.Add(new Item(10002, "������ �ϱ��� #2", "������ �ϱ���. \n \" \"", Item.ItemType.monk_diary));
                itemList.Add(new Item(10003, "������ �ϱ��� #3", "������ �ϱ���. \n \" \"", Item.ItemType.monk_diary));
                itemList.Add(new Item(10004, "������ �ϱ��� #4", "������ �ϱ���. \n \" \"", Item.ItemType.monk_diary));
                itemList.Add(new Item(20001, "������ �޸� #1", "\" \"", Item.ItemType.monk_memo));
                itemList.Add(new Item(20002, "������ �޸� #2", "\" \"", Item.ItemType.monk_memo));
                itemList.Add(new Item(20003, "������ �޸� #3", "\" \"", Item.ItemType.monk_memo));
                itemList.Add(new Item(20004, "������ �޸� #4", "\" \"", Item.ItemType.monk_memo));
                itemList.Add(new Item(20005, "������ �޸� #5", "\" \"", Item.ItemType.monk_memo));
                itemList.Add(new Item(30001, "���ڽ��� �޸� #1", "\" \"", Item.ItemType.child_memo));
                itemList.Add(new Item(30002, "���ڽ��� �޸� #2", "\" \"", Item.ItemType.child_memo));
                itemList.Add(new Item(30003, "���ڽ��� �޸� #3", "\" \"", Item.ItemType.child_memo));
                itemList.Add(new Item(30004, "���ڽ��� �޸� #4", "\" \"", Item.ItemType.child_memo));
                itemList.Add(new Item(30005, "���ڽ��� �޸� #5", "\" \"", Item.ItemType.child_memo));
                itemList.Add(new Item(30006, "���ڽ��� �޸� #6", "\" \"", Item.ItemType.child_memo));
                itemList.Add(new Item(30007, "���ڽ��� �޸� #7", "\" \"", Item.ItemType.child_memo));
                itemList.Add(new Item(30008, "���ڽ��� �޸� #8", "\" \"", Item.ItemType.child_memo));
                itemList.Add(new Item(80001, "���丷�� ���� #1", "���丷�� ����. ��򰡿� ����� �� ���� �� ����.", Item.ItemType.etc));
                itemList.Add(new Item(80002, "���丷�� ���� #2", "���丷�� ����. ��򰡿� ����� �� ���� �� ����.", Item.ItemType.etc));
                itemList.Add(new Item(80003, "��", "��. ���� �� �� ���� �� ����.", Item.ItemType.etc));
                itemList.Add(new Item(80004, "�ν˵�", "�ν˵�. ���� ���� �� ���� �� ����.", Item.ItemType.etc));
                itemList.Add(new Item(80005, "�ص�å", "\" \"", Item.ItemType.etc));
                itemList.Add(new Item(90001, "�����ǿ���#1", "���翡�� �߰��� ����. ���°��� �ƴѰ��� �� ���� ����.", Item.ItemType.etc));
                itemList.Add(new Item(90002, "�����ǿ���#2", "���翡�� �߰��� ����. ���°��� �ƴѰ��� �� ���� ����.", Item.ItemType.etc));
                itemList.Add(new Item(90005, "�����ǿ���#5", "���翡�� �߰��� ����. ���°��� �ƴѰ��� �� ���� ����.", Item.ItemType.etc));
                itemList.Add(new Item(90012, "�����ǿ���#12", "���翡�� �߰��� ����. ���°��� �ƴѰ��� �� ���� ����.", Item.ItemType.etc));
                itemList.Add(new Item(90024, "�����ǿ���#24", "���翡�� �߰��� ����. ���°��� �ƴѰ��� �� ���� ����.", Item.ItemType.etc));
                itemList.Add(new Item(90034, "�����ǿ���#34", "���翡�� �߰��� ����. ���°��� �ƴѰ��� �� ���� ����.", Item.ItemType.etc));
                itemList.Add(new Item(90055, "�����ǿ���#55", "���翡�� �߰��� ����. ���°��� �ƴѰ��� �� ���� ����.", Item.ItemType.etc));
                itemList.Add(new Item(90056, "�����ǿ���#56", "���翡�� �߰��� ����. ���°��� �ƴѰ��� �� ���� ����.", Item.ItemType.etc));
                itemList.Add(new Item(90059, "�����ǿ���#59", "���翡�� �߰��� ����. ���°��� �ƴѰ��� �� ���� ����.", Item.ItemType.etc));
                itemList.Add(new Item(90061, "�����ǿ���#61", "���翡�� �߰��� ����. ���°��� �ƴѰ��� �� ���� ����.", Item.ItemType.etc));
                itemList.Add(new Item(90065, "�����ǿ���#65", "���翡�� �߰��� ����. ���°��� �ƴѰ��� �� ���� ����.", Item.ItemType.etc));
                itemList.Add(new Item(90074, "�����ǿ���#74", "���翡�� �߰��� ����. ���°��� �ƴѰ��� �� ���� ����.", Item.ItemType.etc));
                itemList.Add(new Item(90077, "�����ǿ���#77", "���翡�� �߰��� ����. ���°��� �ƴѰ��� �� ���� ����.", Item.ItemType.etc));
                itemList.Add(new Item(90081, "�����ǿ���#81", "���翡�� �߰��� ����. ���°��� �ƴѰ��� �� ���� ����.", Item.ItemType.etc));
                itemList.Add(new Item(90088, "�����ǿ���#88", "���翡�� �߰��� ����. ���°��� �ƴѰ��� �� ���� ����.", Item.ItemType.etc));
                itemList.Add(new Item(90092, "�����ǿ���#92", "���翡�� �߰��� ����. ���°��� �ƴѰ��� �� ���� ����.", Item.ItemType.etc));
                itemList.Add(new Item(90095, "�����ǿ���#95", "���翡�� �߰��� ����. ���°��� �ƴѰ��� �� ���� ����.", Item.ItemType.etc));
                itemList.Add(new Item(90100, "�����ǿ���#100", "���翡�� �߰��� ����. ���°��� �ƴѰ��� �� ���� ����.", Item.ItemType.etc));
        *///�б� �� �۵��ϸ� ���� ����



    }
    //get �Լ�
    public int GetCurrentItemID()
    {
        return currentItemID;
    }
    public bool GetIsCandleOn()
    {
        return IsCandleOn;
    }
    public bool GetIsRealEmille()
    {
        return IsRealEmille;
    }
    public bool IsBasementOpened()
    {
        int i = Basement[0] + Basement[1];
        if (i == 0)
            return true;
        else
            return false;
    }

    //�� ������ ���� �Լ�
    public void NewCurrentItemID(int _itemID)
    {
        currentItemID = _itemID;
    }
    public void EmilleRoomUnlock(int _itemID)
    {
        switch (_itemID)
        {
            case Constants.key34:
                EmilleRoom[0] = 0;
                break;
            case 90065:
                EmilleRoom[1] = 0;
                break;
            case 90077:
                EmilleRoom[2] = 0;
                break;
            default:
                break;
        }
    }
    public void BasementUnlock(int _itemID)
    {
        switch (_itemID)
        {
            case Constants.half_key1:
                Basement[0] = 0;
                return;
            case Constants.half_key2:
                Basement[1] = 0;
                return;
        }
    }
    public void Letcandleon(bool _is)
    {
        IsCandleOn = _is;
    }
    public void Letrealemille(bool _is)
    {
        IsRealEmille = _is;
    }
}

