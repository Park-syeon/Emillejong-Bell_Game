using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bookshelf : MonoBehaviour
{
    public static Bookshelf instance;
    private bool setActive;

    public GameObject[] books;
    public GameObject selectedBookFrame;
    public GameObject[] monkDiary2;
    public GameObject[] halfKey1;


    private bool FirstActive;
    private bool bookSelected;
    private int cur;
    private int selectedBook;

    private void SelectBook()
    {
        selectedBook = cur;
        bookSelected = true;
        selectedBookFrame.SetActive(true);
        Vector3 position = selectedBookFrame.transform.localPosition;
        position = books[cur].transform.localPosition;
        selectedBookFrame.transform.localPosition = position;
    }
    private void curBook()
    {
        Color color = books[cur].GetComponent<SpriteRenderer>().color;
        
        for(int i = 0; i < books.Length; i++)
        {
            color.b = 1f;
            books[i].GetComponent<SpriteRenderer>().color = color;
        }
        color.b = 0.5f;
        books[cur].GetComponent<SpriteRenderer>().color = color;
    }

    private void checkDiary2()
    {
        for(int i = 0; i < books.Length; i++)
        {
            if(books[i] != monkDiary2[i])
            {
                return;
            }
        }

        Inventory.instance.GetAnItem(Constants.previous_monkdiary2_ID);
        Debug.Log("스님의 일기장 #2를 얻었다.");
    }
    private void checkHalfKey1()
    {
        for (int i = 0; i < books.Length; i++)
        {
            if (books[i] != halfKey1[i])
            {
                return;
            }
        }

        Inventory.instance.GetAnItem(Constants.half_key1);
        Debug.Log("어디다 쓰는지 모를 반쪽짜리 열쇠를 얻었다.");
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        setActive = false;
        bookSelected = false;
        FirstActive = true;
        selectedBookFrame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (setActive)
        {
            if (FirstActive)
            {
                bookSelected = false;
                cur = 0;
                FirstActive = false;
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                if (bookSelected)
                {
                    //배열 바꾸기
                    GameObject temp;
                    temp = books[selectedBook];
                    books[selectedBook] = books[cur];
                    books[cur] = temp;
                    //책의 위치 바꾸기
                    Vector3 position = books[selectedBook].transform.position;
                    books[selectedBook].transform.position = books[cur].transform.position;
                    books[cur].transform.position = position;
                    bookSelected = false;
                    selectedBookFrame.SetActive(false);

                    checkDiary2();
                    checkHalfKey1();
                }
                else
                {
                    SelectBook();
                }
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if(cur < books.Length - 1)
                {
                    cur++;
                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if(cur > 0)
                {
                    cur--;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                setActive = false;
                bookSelected = false;
                FirstActive = true;
                selectedBookFrame.SetActive(false);
            }
            curBook();
        }
    }
}
