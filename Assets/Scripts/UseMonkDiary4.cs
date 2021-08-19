using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseMonkDiary4 : MonoBehaviour
{
    public static UseMonkDiary4 instance;

    private bool activated;

    public GameObject diary4;
    public GameObject[] ob = new GameObject[4];

    public int[] answer = new int[4] { 1, 4, 2, 3 };
    private int[] Useranswer = new int[4] { 0, 0, 0, 0 };

    private int[] choosed = new int[4] {9, 9, 9, 9};    //0�̸� �̹� �����ߴ���
    private int cur = 0;
    private int curanswerNum = 0;



    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
        activated = false;
        cur = 0;
        curanswerNum = 0;
        for (int i = 0; i < Useranswer.Length; i++)
        {
            Useranswer[i] = 0;
        }
        for (int i = 0; i < choosed.Length; i++)
        {
            choosed[i] = 9;
        }
        for (int i = 0; i < ob.Length; i++)
        {
            ob[i].SetActive(true);
        }
        diary4.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {

            diary4.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                for(int i = cur + 1; i < 4; i++)
                {
                    if (choosed[i] != 0)
                    {
                        cur = i;
                        break;
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                for (int i = cur - 1; i >= 0; i--)
                {
                    if (choosed[i] != 0)
                    {
                        cur = i;
                        break;
                    }
                }
            }
            else if(Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.Return))
            {
                if(choosed[cur] == 0)
                {
                    Debug.LogError("������ϴ� ��������.");
                }
                else
                {
                    choosed[cur] = 0;
                    ob[cur].gameObject.SetActive(false);
                    Useranswer[curanswerNum] = cur + 1;
                    curanswerNum++;

                }
                for (int i = 0; i < 4; i++)
                {
                    if (choosed[i] != 0)
                    {
                        cur = i;
                        break;
                    }
                }
            }
            else
            {

            }
            selectedIcon();

            //4������ ��� �������� ��
            if (curanswerNum == 4)
            {
                Debug.Log("���������ƴѰ���");
                checkAnswer();
                ResetDiary4();
                Inventory.instance.SetpreventExec2(true);
            }

        }
        
    }
    private void selectedIcon()
    {
        Color color = ob[cur].gameObject.GetComponent<SpriteRenderer>().color;
        color.b = 1f;
        for(int i = 0; i < ob.Length; i++)
        {
            ob[i].GetComponent<SpriteRenderer>().color = color;
        }
        color.b = 0.8f;
        ob[cur].GetComponent<SpriteRenderer>().color = color;
    }
    private void checkAnswer()
    {
        for(int i = 0; i < 4; i++)
        {
            if(Useranswer[i] != answer[i])
            {
                Debug.Log("������ �ƴϴ�.");
                return;
            }
        }

        Debug.Log("�ϱ���4�� �����.");
        Inventory.instance.GetAnItem(Constants.real_monkdiary4_ID);
        Inventory.instance.RemoveAnItem(Constants.previous_monkdiary4_ID);

        Inventory.instance.setActivated(false);
    }
    private void ResetDiary4()
    {
        for (int i = 0; i < ob.Length; i++)
        {
            ob[i].gameObject.SetActive(true);
        }
        cur = 0;
        curanswerNum = 0;
        diary4.SetActive(false);
        activated = false;
        Inventory.instance.itemSetactive(true);
        for (int i = 0; i < Useranswer.Length; i++)
        {
            Useranswer[i] = 0;
        }
        for (int i = 0; i < choosed.Length; i++)
        {
            choosed[i] = 9;
        }
        
    }
    public void activeMonkDiary4(int _itemID)
    {
        Debug.Log("diary41");
        if(_itemID == Constants.previous_monkdiary4_ID)
            activated = true;
    }
}
