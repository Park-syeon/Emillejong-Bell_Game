using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseMonkDiary3 : MonoBehaviour
{
    
    private bool activated;
    public InputField _11003_inputField;
    public string monkdiary3Code;

    public static UseMonkDiary3 instance;

    #region ?̱???
    private void Awake()    //?̱???!!
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

    private void Start()
    {
        instance = this;
        activated = false;
        _11003_inputField.gameObject.SetActive(false);
    }

    void Update()
    {
        if (activated)
        {
            _11003_inputField.gameObject.SetActive(true);   //?Է?â?? ?Է¹ޱ?
            if (Input.GetKeyDown(KeyCode.Return))   
            {
                Inventory.instance.SetpreventExec2(true);
                Quiz11003();
                _11003_inputField.gameObject.SetActive(false);
                activated = false;
            }
            if (!Inventory.instance.getActivated())
            {
                Inventory.instance.SetpreventExec2(true);
                _11003_inputField.gameObject.SetActive(false);
                activated = false;
            }
            
        }
    }



    private void Quiz11003()    //???? ???? ????
    {
        if (_11003_inputField.text == monkdiary3Code)
        {
//            Debug.Log("????????2");
            Inventory.instance.GetAnItem(Constants.real_monkdiary3_ID);
            SeveralDialogue.instance.AfterGetDiary3();
            if (FindObjectOfType<setActiveDiary4>())
            {
                setActiveDiary4.instance.active();
            }
 //           Debug.Log("????????3");
            Inventory.instance.RemoveAnItem(Constants.previous_monkdiary3_ID); ;
//            Debug.Log("????????4");

            Inventory.instance.setActivated(false);

//            Debug.Log("?ص??? ?????? ?ϱ??? #3?? ??????.");
        }
        else
        {
            SeveralDialogue.instance.Failure();
            _11003_inputField.text = "";
            Inventory.instance.itemSetactive(true);
        }

    }
    public void activeMonkDiary3(int _itemID)   //?????? ?ϱ??? 3 ???? Ȱ??ȭ
    {
        if(_itemID == Constants.previous_monkdiary3_ID)
            activated = true;
        else
        {

        }
    }
}