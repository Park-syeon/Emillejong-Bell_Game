using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryFlow : MonoBehaviour
{
    public static StoryFlow instance;

    //��¥ ������ �ϱ���1�� �׵� �� ���Թ濡�� ���� �� ����
    //������ ��¥ �ϱ���4�� �׵� �� ���ڽ��� �޸�#8�� �׵��� �� �ִ� �ݶ��̴� Ȱ��ȭ��
    //���� �ټ����� ���ƾ� ���Ͻ� ������ ���� (���Ͻǿ����� �ݶ��̴� Ȱ��ȭ)
    //���Ͻ� ���踦 ��� �� ���Ͻ� ���� ����

    //�������� �׵��Ͽ������� Inventory.instance.FindItem(int _itemID) �Լ��� ã�� �� ���� (return�� bool ����)
    //���� �ټ����� ���Ҵ����� Requirement.instance.getHalfKeyAble(); �� �˻� - �̰� �׵��� pond.cs����
    //���Ͻ� ���踦 ��� ������� Requirement.instance.IsBasementOpened();
    private bool CanGetOutOfMonkRoom = false;
    public GameObject ChildMemo8;
    private bool CanGetIntoBasement = false;
    
    public void GotRealMonkDiary1(bool _is)
    {
        CanGetOutOfMonkRoom = _is;
    }

    public void ActiveChildMemo8()
    {
        ChildMemo8.SetActive(true);
    }

    public void SetCanGetIntoBasement(bool _is)
    {
        CanGetIntoBasement = _is;
    }






    // Start is called before the first frame update
    void Start()
    {
        ChildMemo8.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!CanGetOutOfMonkRoom)
        {
            //���Թ濡�� ���� �� ���� �Ǵ� ���Թ游 �� �� ����?
        }
        if (CanGetIntoBasement)
        {
            //���Ͻ� �� �� ����
        }
    }
}
