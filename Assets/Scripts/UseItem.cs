/*

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseItem : MonoBehaviour
{
    //Inventory�� ���� ���õ� public int nowItem �߰� //protected?
    
    public InputField _11003_inputField;
    private string Answer11003 = "�ϳ��Ѽ�";


    public static UseItem instance;
    private int itemID;
    private bool Activated_11003;
    private bool Activated_11004;

    public void usingItem(int _itemID)
    {
        itemID = _itemID;
        switch (itemID)
        {
            case 11003:
                Activated_11003 = true;
                break;
            case 11004:
                Activated_11004 = true;
                break;
            default:
                break;
        }
    }
    public void UseSeveral()
    {

    }
    public void Quiz11003()
    {
        if (_11003_inputField.text == Answer11003)
        {
            Debug.Log("�������2");
            int a = 10003;
            Inventory.instance.GetAnItem(a);
            Debug.Log("�������3");
            int b = 11003;
            Inventory.instance.RemoveAnItem(b);
            Debug.Log("�������4");

            Inventory.instance.goSetactive(false);

            Debug.Log("�ص��� ������ �ϱ��� #3�� �����.");
        }
        else
        {
            Debug.Log("(�ƴ� �� ����.)");
            Inventory.instance.itemSetactive(true);
        }
      
    }
    public void Quiz11004()
    {

    }


    // Start is called before the first frame update
    void Start()
    {
        _11003_inputField.gameObject.SetActive(false);
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

        if (itemID != 0)
        {
            if (Activated_11004)
            {

            }
        }
    }
}
*/
