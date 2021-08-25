using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bookshelf : MonoBehaviour
{
    public static Bookshelf instance;
    private bool activated;
    #region ΩÃ±€≈Ê
    private void Awake()    //ΩÃ±€≈Ê!!
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

    public GameObject[] books;
    public GameObject selectedBookFrame;
    public GameObject[] monkDiary2;
    public GameObject[] halfKey1;


    private bool FirstActive;
    private bool bookSelected;
    private int cur;
    private int selectedBook;

    //getset«‘ºˆ
    public bool getActivated()
    {
        return activated;
    }
    public void setActivated(bool _is)
    {
        activated = _is;
    }

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
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        activated = false;
        bookSelected = false;
        FirstActive = true;
        selectedBookFrame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
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
                    //πËø≠ πŸ≤Ÿ±‚
                    GameObject temp;
                    temp = books[selectedBook];
                    books[selectedBook] = books[cur];
                    books[cur] = temp;
                    //√•¿« ¿ßƒ° πŸ≤Ÿ±‚
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
                activated = false;
                bookSelected = false;
                FirstActive = true;
                selectedBookFrame.SetActive(false);
            }
            curBook();
        }
    }
}
