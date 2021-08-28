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
            _11003_inputField.gameObject.SetActive(true);   //입력창에 입력받기
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



    private void Quiz11003()    //퀴즈 정답 여부
    {
        if (_11003_inputField.text == monkdiary3Code)
        {
//            Debug.Log("여기까지2");
            Inventory.instance.GetAnItem(Constants.real_monkdiary3_ID);
            SeveralDialogue.instance.AfterGetDiary3();
            Inventory.instance.GetAnItem(Constants.previous_monkdiary4_ID);
 //           Debug.Log("여기까지3");
            Inventory.instance.RemoveAnItem(Constants.previous_monkdiary3_ID); ;
//            Debug.Log("여기까지4");

            Inventory.instance.setActivated(false);

//            Debug.Log("해독된 스님의 일기장 #3을 얻었다.");
        }
        else
        {
            SeveralDialogue.instance.Failure();
            _11003_inputField.text = "";
            Inventory.instance.itemSetactive(true);
        }

    }
    public void activeMonkDiary3(int _itemID)   //스님의 일기장 3 퀴즈 활성화
    {
        if(_itemID == Constants.previous_monkdiary3_ID)
            activated = true;
        else
        {

        }
    }
}