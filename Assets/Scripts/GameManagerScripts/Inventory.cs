using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    #region 싱글톤
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
    #endregion

    public static Inventory instance;

    private InventorySlot[] slots;
    public GameObject emptySlot;
    public Text emptyText;

    private List<Item> InventoryItemList;   //플레이어가 소지한 아이템 리스트
    private List<Item> InventoryTabList;    //선택한 탭에 따라 다르게 보여질 아이템 리스트     //어차피 템 개수/종류 정해져 있으니까 배열을 만들어두고 1, 0 넣는 식이 낫나

    private List<Item> itemList;

    //left UI
    public Text Description_Text;   //부연설명
    public Image Picture;

    public Transform tf;    //slots 부모객체

    public GameObject go;   //인벤토리 활성화 불활성화
    public GameObject[] selectedTabImages;  //탭 이미지 배열  0(스님의 일기장(, (1스님의 쪽지), 2(동자승의 쪽지), 3기타?
    private const int columnNum = 2; //탭의 가로 요소 개수
    private const int rowNum = 2; // 캡의 세로요소 개수

    private int selectedItem;
    private int selectedTab;
    private int selectedPageItem; // 한 페이지에서의 아이템의 번ㄴ호

    private int page;   //현재페이지
    private int pageNum;  //
    private const int MAX_SLOT_COUNT = 8; //한 페이지 최대슬롯개수

    private bool activated;
    private bool tabActivated;
    private bool itemActivated;
    private bool stopKeyInput;
    private bool preventExec;
    private bool preventExec2;

    private WaitForSeconds waitTime = new WaitForSeconds(0.01f);

    //getset함수
    public bool getActivated()
    {
        return activated;
    }
    public void setActivated(bool _is)
    {
        activated = _is;
        if (!activated)
        {
            StopAllCoroutines();
            go.SetActive(false);
            tabActivated = false;
            itemActivated = false;
        }
    }
    public void setStopKeyInput(bool _is)
    {
        stopKeyInput = _is;
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        InventoryItemList = new List<Item>();
        InventoryTabList = new List<Item>();
        slots = tf.GetComponentsInChildren<InventorySlot>();
        go.SetActive(false);
        tabActivated = false;
        itemActivated = false;
        clearEmptySlot();
        /*  //인벤토리에 데이터베이스에 있는 모든 아이템 집어넣기
                for(int i = 0; i < DatabaseManager.instance.itemList.Count; i++)
                {
                    InventoryItemList.Add(DatabaseManager.instance.itemList[i]);
                }
        
        instance.GetAnItem(80001);
        instance.GetAnItem(80002);
        */
    }
    public void RemoveSlot()
    {
        clearEmptySlot();
        for (int i = 0; i < slots.Length || i < MAX_SLOT_COUNT; i++)
        {
            slots[i].RemoveItem();
            slots[i].gameObject.SetActive(false);
        }
    }   //인벤토리 슬롯 초기화
    public void ShowTab()
    {
        RemoveSlot();
        SelectedTab();
    }   //탭 활성화
    public void SelectedTab()
    {
        StopAllCoroutines();
        Color color = selectedTabImages[selectedTab].GetComponent<Image>().color;
        color.a = 0.0f;
        for (int i = 0; i < selectedTabImages.Length; i++)
        {
            selectedTabImages[i].GetComponent<Image>().color = color;
        }
        Description_Text.text = "";
        Picture = null;
        StartCoroutine(SelectedTabEffectCoroutine());
    }
    IEnumerator SelectedTabEffectCoroutine()
    {
        while (tabActivated)
        {
            Color color = selectedTabImages[selectedTab].GetComponent<Image>().color;
            while (color.a < 0.5f)
            {
                color.a += 0.03f;
                selectedTabImages[selectedTab].GetComponent<Image>().color = color;
                yield return waitTime;
            }
            yield return new WaitForSeconds(0.3f);
        }
    }
    public void ShowItem()
    {
        InventoryTabList.Clear();
        RemoveSlot();   //슬롯 비우기
        selectedItem = 0;   //처음 선택된 아이템은 (탭에서) 젤 첫 아이템
        switch (selectedTab)
        {
            case 0:
                for (int i = 0; i < InventoryItemList.Count; i++)
                {
                    if (Item.ItemType.monk_diary == InventoryItemList[i].itemType)
                        InventoryTabList.Add(InventoryItemList[i]);
                }
                break;
            case 1:
                for (int i = 0; i < InventoryItemList.Count; i++)
                {
                    if (Item.ItemType.monk_memo == InventoryItemList[i].itemType)
                        InventoryTabList.Add(InventoryItemList[i]);
                }
                break;
            case 2:
                for (int i = 0; i < InventoryItemList.Count; i++)
                {
                    if (Item.ItemType.child_memo == InventoryItemList[i].itemType)
                        InventoryTabList.Add(InventoryItemList[i]);
                }
                break;
            case 3:
                for (int i = 0; i < InventoryItemList.Count; i++)
                {
                    if (Item.ItemType.etc == InventoryItemList[i].itemType)
                        InventoryTabList.Add(InventoryItemList[i]);
                }
                break;
        }   //텝에 따라서 플레이어 소유 아이템을 분류
        page = 0;
        pageNum = ((InventoryTabList.Count - 1) / MAX_SLOT_COUNT) +1;
        SelectedItem();

    }   //아이템 
    public void ShowPage()
    {
        RemoveSlot();
        page = selectedItem / MAX_SLOT_COUNT;
        selectedPageItem = selectedItem % MAX_SLOT_COUNT;
        for (int i = 0; (i < MAX_SLOT_COUNT) && (i < (InventoryTabList.Count - page*MAX_SLOT_COUNT)); i++)
        {
            slots[i].Additem(InventoryTabList[MAX_SLOT_COUNT * page + i]);  //각 페이지에 0~7, 8~15, 16~23 번 아이템이 슬롯에 나타남
            slots[i].gameObject.SetActive(true);
        }   //슬롯에 아이템 정보 저장
    }
    public void SelectedItem()
    {
        //StopAllCoroutines();
        ShowPage();

        Debug.Log("tablist" + InventoryTabList.Count.ToString());
        Debug.Log("selectedItem" + selectedItem.ToString());

        if (InventoryTabList.Count > 0)
        {
            Color color = slots[0].selected_Item.GetComponent<Image>().color;
            color.a = 0f;
            for (int i = 0; i < MAX_SLOT_COUNT; i++)
            {
                slots[i].selected_Item.GetComponent<Image>().color = color;
            }
            color.a = 0.5f;
            slots[selectedPageItem].selected_Item.GetComponent<Image>().color = color;
            Description_Text.text = InventoryTabList[selectedItem].itemDescription;
            if (Picture)
            {
                Picture.sprite = InventoryTabList[selectedItem].itemPicture;
            }
        }
        else
        {
            writeEmptySlot();
        }
    }

    public void clearEmptySlot()
    {
        Color color = emptySlot.GetComponent<Image>().color;
        color.a = 0f;
        emptySlot.GetComponent<Image>().color = color;
        emptyText.text = "";
    }
    public void writeEmptySlot()
    {
        Color color = emptySlot.GetComponent<Image>().color;
        color.a = 0.5f;
        emptySlot.GetComponent<Image>().color = color;
        emptyText.text = "아이템이 없습니다.";

    }
    public void GetAnItem(int _itemID)
    {
        Debug.Log("여기까지2.1");
        for (int i = 0; i < DatabaseManager.instance.itemList.Count; i++)
        {
            for (int k = 0; k < InventoryItemList.Count; k++)
            {
                if(InventoryItemList[k].itemID == _itemID)
                {
                    Debug.Log("이미 있는 아이템이다.");  //사실 나오면 뭔가 잘못된거다.
                    return;
                }
            }
            if (_itemID == DatabaseManager.instance.itemList[i].itemID)
            {
                InventoryItemList.Add(DatabaseManager.instance.itemList[i]);
                Debug.Log("아이템 " + DatabaseManager.instance.itemList[i].itemName + " 을 얻었다.");
                return;
            }

        }
        Debug.LogError("데이터베이스에 해당 id를 가진 아이템이 없다.");
    }
    public void RemoveAnItem(int _itemID)
    {
        for (int i = 0; i < InventoryItemList.Count; i++)
        {
            if (_itemID == InventoryItemList[i].itemID)
            {
                InventoryItemList.RemoveAt(i);
                return;
            }
        }
        Debug.LogError("데이터베이스에 해당 id를 가진 아이템이 없다.");
    }
    public void goSetactive(bool _active)
    {
        go.SetActive(_active);
    }
    public void itemSetactive(bool _active)
    {
        itemActivated = _active;
    }
    public bool FindItem(int _itemID)
    {
        for(int i = 0; i< InventoryItemList.Count; i++)
        {
            if (InventoryItemList[i].itemID == _itemID)
                return true;
        }

        return false;
    }


    // Update is called once per frame
    void Update()
    {
        if (!stopKeyInput)
        {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                activated = !activated;
                if (activated)
                {
                    go.SetActive(true);
                    selectedTab = 0;
                    tabActivated = true;
                    itemActivated = false;
                    ShowTab();
                }
                else
                {
                    StopAllCoroutines();
                    go.SetActive(false);
                    tabActivated = false;
                    itemActivated = false; 
                }

            }
        
            if (activated)
            {
                if (tabActivated)
                {
                    if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        if ((selectedTab / columnNum) + 1 < rowNum)
                        {
                            selectedTab += columnNum;
                            SelectedTab();
                        }
                        else { };
                    }

                    else if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        if ((selectedTab / columnNum) != 0)
                        {
                            selectedTab -= columnNum;
                            SelectedTab();
                        }
                        else { };
                    }

                    else if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        if(selectedTab < selectedTabImages.Length - 1)
                        {
                            selectedTab++;
                            SelectedTab();
                        }
                        else {  };
                    }

                    else if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        if (selectedTab > 0)
                        {
                            selectedTab--;
                            SelectedTab();
                        }
                        else { };
                    }
                    else if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.G))
                    {
                        Color color = selectedTabImages[selectedTab].GetComponent<Image>().color;
                        color.a = 0.5f;
                        selectedTabImages[selectedTab].GetComponent<Image>().color = color;

                        tabActivated = false;
                        itemActivated = true;
                        preventExec = true;
                        ShowItem();
                    }
                }
                else if (itemActivated)
                {
                    if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        if (selectedPageItem < MAX_SLOT_COUNT - 1   &&  selectedItem < InventoryTabList.Count - 1)
                        {
                            selectedItem++;
                            SelectedItem();
                        }
                        else { };
                    }
                    else if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        if (selectedPageItem == 0)
                        {
                            itemActivated = false;
                            tabActivated = true;
                            ShowTab();
                        }
                        else
                        {
                            selectedItem--;
                            SelectedItem();
                        }
                    }
                    else if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        if (page < pageNum - 1)
                        {
                            selectedItem = (selectedItem + MAX_SLOT_COUNT) < InventoryTabList.Count ? selectedItem + MAX_SLOT_COUNT : InventoryTabList.Count - 1;
                            SelectedItem();
                        }
                        else { };
                        SelectedItem();
                    }
                    else if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        if (page > 0)
                        {
                            selectedItem -= MAX_SLOT_COUNT;
                            SelectedItem();
                        }
                        else { };
                        SelectedItem();
                    }
                    else if ((Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.G)) && !preventExec && !preventExec2)
                    {
                        Debug.Log("dkdkdkkd");
                        itemActivated = false;
                        Debug.Log("여기까진 됐는데 말이죠");
                        if(selectedItem < InventoryItemList.Count)
                            InventoryTabList[selectedItem].useItem();
                        //go.SetActive(false);
                    }
                    else { }
                }
                if (Input.GetKeyUp(KeyCode.KeypadEnter) || Input.GetKeyUp(KeyCode.G))
                {
                    preventExec = false;
                    preventExec2 = false;
                }

            }
        }

    }

    public void SetpreventExec2(bool _is)
    {
        preventExec2 = true;
    }
}
