/*

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseItem : MonoBehaviour
{
    //Inventory에 현재 선택된 public int nowItem 추가 //protected?
    
    public InputField _11003_inputField;
    private string Answer11003 = "하나둘셋";


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
            Debug.Log("여기까지2");
            int a = 10003;
            Inventory.instance.GetAnItem(a);
            Debug.Log("여기까지3");
            int b = 11003;
            Inventory.instance.RemoveAnItem(b);
            Debug.Log("여기까지4");

            Inventory.instance.goSetactive(false);

            Debug.Log("해독된 스님의 일기장 #3을 얻었다.");
        }
        else
        {
            Debug.Log("(아닌 것 같다.)");
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
