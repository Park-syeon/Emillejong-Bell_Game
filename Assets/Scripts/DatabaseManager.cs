using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager instance;

    private void Awake()    //싱글톤!!
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


        //얘네 꼭 awake에 넣어야하나
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
    private int[] EmilleRoom = new int[3] { 9,9,9 };    //0이면 해제된거, 0이 아니면 잠긴거
    private int[] Basement = new int[2] { 9, 9 }; //0이면 해제된거, 0이 아니면 잠긴거
    private bool IsCandleOn = false;
    private bool IsRealEmille = false;  //이거 왜 있는지 모르겠음


    public string[] switch_name;
    public bool[] switches;

    public List<Item> itemList = new List<Item>();

    // Start is called before the first frame update
    void Start()
    {
        /*
        아이템 아이디(ItemID)
        스님의 일기장 #1 사용 전  : 11001
        스님의 일기장 #3 사용 전  : 11003
        스님의 일기장 #4 사용 전  : 11004
        스님의 일기장 #1 ~ #4     : 10001, 10002, 10003, 10004
        스님의 메모 #1 ~ #5       : 20001 ~ 20005
        동자승의 메모 #1 ~ #8     : 30001 ~ 30008
        스님과 왕과의 편지 #1, #2 : 40001, 40002
        가짜 에밀레종 제작 문서   : 50001
        진짜 에밀레종 제작 문서   : 60001
        지하실의 스님의 진짜 일기장 : 70001
        기타 아이템
            1. 반토막난 열쇠#1    : 80001
            2. 반토막난 열쇠#2    : 80002
            3. 삽                 : 80003
            4. 부싯돌             : 80004      //부싯돌은 일기장1을 읽기 위해 양초에 불을 붙이는 역할
            5. 해독책             : 80005
            6. 서재의 열쇠들      : 90001, 90002, 90005, 90012, 90024, 90034(*), 90055, 90056, 90059, 90061, 90065(*), 90074, 90077(*), 90081, 90088, 90092, 90095, 90100

         */
        /*
                itemList.Add(new GeneralItem(11001, "스님의 일기장 #1", "스님의 일기장. 아무것도 보이지 않는다. 무언가에 사용해야할 것 같다.", Item.ItemType.monk_diary));
                itemList.Add(new Item(11003, "스님의 일기잔 #3", "스님의 일기장. 알 수 없는 말이 적혀있다. 해독해야 할 것 같다.", Item.ItemType.monk_diary));
                itemList.Add(new Item(11004, "스님의 일기장 #4", "스님의 일기장. 찢어져 순서대로 맞춰야 할 것 같다.", Item.ItemType.monk_diary));
                itemList.Add(new Item(10001, "스님의 일기장 #1", "스님의 일기장. \n \"전하께서 선왕의 공덕을 알리기 위해 종을 만들라 하셨다.그러나 시주받은 많은 재료와 돈을 사용했음에도 불구하고 종에 소리가 울리지 않고 있다.이게 어찌 된 일일까 ? 더 이상 종을 다시 만들 여력이 되지 않는다.백성들에게 더는 시주받을것도 없건만, 전하께서는 백성들에게 시주를 더 받으라 하신다.오늘은 어떤 과부의 집에 들렀으나 시주할 것이 없고 있는 것은 두 아이뿐이라 한다..결국 그 집에서는 시주를 받지 않고 돌아왔다.하지만..오늘도 역시나 종에 소리는 울리지 않았다.\"", Item.ItemType.monk_diary));
                itemList.Add(new Item(10002, "스님의 일기장 #2", "스님의 일기장. \n \" \"", Item.ItemType.monk_diary));
                itemList.Add(new Item(10003, "스님의 일기장 #3", "스님의 일기장. \n \" \"", Item.ItemType.monk_diary));
                itemList.Add(new Item(10004, "스님의 일기장 #4", "스님의 일기장. \n \" \"", Item.ItemType.monk_diary));
                itemList.Add(new Item(20001, "스님의 메모 #1", "\" \"", Item.ItemType.monk_memo));
                itemList.Add(new Item(20002, "스님의 메모 #2", "\" \"", Item.ItemType.monk_memo));
                itemList.Add(new Item(20003, "스님의 메모 #3", "\" \"", Item.ItemType.monk_memo));
                itemList.Add(new Item(20004, "스님의 메모 #4", "\" \"", Item.ItemType.monk_memo));
                itemList.Add(new Item(20005, "스님의 메모 #5", "\" \"", Item.ItemType.monk_memo));
                itemList.Add(new Item(30001, "동자승의 메모 #1", "\" \"", Item.ItemType.child_memo));
                itemList.Add(new Item(30002, "동자승의 메모 #2", "\" \"", Item.ItemType.child_memo));
                itemList.Add(new Item(30003, "동자승의 메모 #3", "\" \"", Item.ItemType.child_memo));
                itemList.Add(new Item(30004, "동자승의 메모 #4", "\" \"", Item.ItemType.child_memo));
                itemList.Add(new Item(30005, "동자승의 메모 #5", "\" \"", Item.ItemType.child_memo));
                itemList.Add(new Item(30006, "동자승의 메모 #6", "\" \"", Item.ItemType.child_memo));
                itemList.Add(new Item(30007, "동자승의 메모 #7", "\" \"", Item.ItemType.child_memo));
                itemList.Add(new Item(30008, "동자승의 메모 #8", "\" \"", Item.ItemType.child_memo));
                itemList.Add(new Item(80001, "반토막난 열쇠 #1", "반토막난 열쇠. 어딘가에 사용할 수 있을 것 같다.", Item.ItemType.etc));
                itemList.Add(new Item(80002, "반토막난 열쇠 #2", "반토막난 열쇠. 어딘가에 사용할 수 있을 것 같다.", Item.ItemType.etc));
                itemList.Add(new Item(80003, "삽", "삽. 땅을 팔 수 있을 것 같다.", Item.ItemType.etc));
                itemList.Add(new Item(80004, "부싯돌", "부싯돌. 불을 붙일 수 있을 것 같다.", Item.ItemType.etc));
                itemList.Add(new Item(80005, "해독책", "\" \"", Item.ItemType.etc));
                itemList.Add(new Item(90001, "서재의열쇠#1", "서재에서 발견한 열쇠. 쓰는건지 아닌건지 알 수가 없다.", Item.ItemType.etc));
                itemList.Add(new Item(90002, "서재의열쇠#2", "서재에서 발견한 열쇠. 쓰는건지 아닌건지 알 수가 없다.", Item.ItemType.etc));
                itemList.Add(new Item(90005, "서재의열쇠#5", "서재에서 발견한 열쇠. 쓰는건지 아닌건지 알 수가 없다.", Item.ItemType.etc));
                itemList.Add(new Item(90012, "서재의열쇠#12", "서재에서 발견한 열쇠. 쓰는건지 아닌건지 알 수가 없다.", Item.ItemType.etc));
                itemList.Add(new Item(90024, "서재의열쇠#24", "서재에서 발견한 열쇠. 쓰는건지 아닌건지 알 수가 없다.", Item.ItemType.etc));
                itemList.Add(new Item(90034, "서재의열쇠#34", "서재에서 발견한 열쇠. 쓰는건지 아닌건지 알 수가 없다.", Item.ItemType.etc));
                itemList.Add(new Item(90055, "서재의열쇠#55", "서재에서 발견한 열쇠. 쓰는건지 아닌건지 알 수가 없다.", Item.ItemType.etc));
                itemList.Add(new Item(90056, "서재의열쇠#56", "서재에서 발견한 열쇠. 쓰는건지 아닌건지 알 수가 없다.", Item.ItemType.etc));
                itemList.Add(new Item(90059, "서재의열쇠#59", "서재에서 발견한 열쇠. 쓰는건지 아닌건지 알 수가 없다.", Item.ItemType.etc));
                itemList.Add(new Item(90061, "서재의열쇠#61", "서재에서 발견한 열쇠. 쓰는건지 아닌건지 알 수가 없다.", Item.ItemType.etc));
                itemList.Add(new Item(90065, "서재의열쇠#65", "서재에서 발견한 열쇠. 쓰는건지 아닌건지 알 수가 없다.", Item.ItemType.etc));
                itemList.Add(new Item(90074, "서재의열쇠#74", "서재에서 발견한 열쇠. 쓰는건지 아닌건지 알 수가 없다.", Item.ItemType.etc));
                itemList.Add(new Item(90077, "서재의열쇠#77", "서재에서 발견한 열쇠. 쓰는건지 아닌건지 알 수가 없다.", Item.ItemType.etc));
                itemList.Add(new Item(90081, "서재의열쇠#81", "서재에서 발견한 열쇠. 쓰는건지 아닌건지 알 수가 없다.", Item.ItemType.etc));
                itemList.Add(new Item(90088, "서재의열쇠#88", "서재에서 발견한 열쇠. 쓰는건지 아닌건지 알 수가 없다.", Item.ItemType.etc));
                itemList.Add(new Item(90092, "서재의열쇠#92", "서재에서 발견한 열쇠. 쓰는건지 아닌건지 알 수가 없다.", Item.ItemType.etc));
                itemList.Add(new Item(90095, "서재의열쇠#95", "서재에서 발견한 열쇠. 쓰는건지 아닌건지 알 수가 없다.", Item.ItemType.etc));
                itemList.Add(new Item(90100, "서재의열쇠#100", "서재에서 발견한 열쇠. 쓰는건지 아닌건지 알 수가 없다.", Item.ItemType.etc));
        *///읽기 잘 작동하면 삭제 예정



    }
    //get 함수
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

    //각 데이터 수정 함수
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

