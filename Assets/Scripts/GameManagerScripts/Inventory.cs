using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    #region �̱���
    private void Awake()    //�̱���!!
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

    private List<Item> InventoryItemList;   //�÷��̾ ������ ������ ����Ʈ
    private List<Item> InventoryTabList;    //������ �ǿ� ���� �ٸ��� ������ ������ ����Ʈ     //������ �� ����/���� ������ �����ϱ� �迭�� �����ΰ� 1, 0 �ִ� ���� ����

    private List<Item> itemList;

    //left UI
    public Text Description_Text;   //�ο�����
    public Image Picture;

    public Transform tf;    //slots �θ�ü

    public GameObject go;   //�κ��丮 Ȱ��ȭ ��Ȱ��ȭ
    public GameObject[] selectedTabImages;  //�� �̹��� �迭  0(������ �ϱ���(, (1������ ����), 2(���ڽ��� ����), 3��Ÿ?
    private const int columnNum = 2; //���� ���� ��� ����
    private const int rowNum = 2; // ĸ�� ���ο�� ����

    private int selectedItem;
    private int selectedTab;
    private int selectedPageItem; // �� ������������ �������� ����ȣ

    private int page;   //����������
    private int pageNum;  //
    private const int MAX_SLOT_COUNT = 8; //�� ������ �ִ뽽�԰���

    private bool activated;
    private bool tabActivated;
    private bool itemActivated;
    private bool stopKeyInput;
    private bool preventExec;
    private bool preventExec2;

    private WaitForSeconds waitTime = new WaitForSeconds(0.01f);

    //getset�Լ�
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
        /*  //�κ��丮�� �����ͺ��̽��� �ִ� ��� ������ ����ֱ�
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
    }   //�κ��丮 ���� �ʱ�ȭ
    public void ShowTab()
    {
        RemoveSlot();
        SelectedTab();
    }   //�� Ȱ��ȭ
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
        RemoveSlot();   //���� ����
        selectedItem = 0;   //ó�� ���õ� �������� (�ǿ���) �� ù ������
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
        }   //�ܿ� ���� �÷��̾� ���� �������� �з�
        page = 0;
        pageNum = ((InventoryTabList.Count - 1) / MAX_SLOT_COUNT) +1;
        SelectedItem();

    }   //������ 
    public void ShowPage()
    {
        RemoveSlot();
        page = selectedItem / MAX_SLOT_COUNT;
        selectedPageItem = selectedItem % MAX_SLOT_COUNT;
        for (int i = 0; (i < MAX_SLOT_COUNT) && (i < (InventoryTabList.Count - page*MAX_SLOT_COUNT)); i++)
        {
            slots[i].Additem(InventoryTabList[MAX_SLOT_COUNT * page + i]);  //�� �������� 0~7, 8~15, 16~23 �� �������� ���Կ� ��Ÿ��
            slots[i].gameObject.SetActive(true);
        }   //���Կ� ������ ���� ����
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
        emptyText.text = "�������� �����ϴ�.";

    }
    public void GetAnItem(int _itemID)
    {
        Debug.Log("�������2.1");
        for (int i = 0; i < DatabaseManager.instance.itemList.Count; i++)
        {
            for (int k = 0; k < InventoryItemList.Count; k++)
            {
                if(InventoryItemList[k].itemID == _itemID)
                {
                    Debug.Log("�̹� �ִ� �������̴�.");  //��� ������ ���� �߸��ȰŴ�.
                    return;
                }
            }
            if (_itemID == DatabaseManager.instance.itemList[i].itemID)
            {
                InventoryItemList.Add(DatabaseManager.instance.itemList[i]);
                Debug.Log("������ " + DatabaseManager.instance.itemList[i].itemName + " �� �����.");
                return;
            }

        }
        Debug.LogError("�����ͺ��̽��� �ش� id�� ���� �������� ����.");
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
        Debug.LogError("�����ͺ��̽��� �ش� id�� ���� �������� ����.");
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
                        Debug.Log("������� �ƴµ� ������");
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
