using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingUI : MonoBehaviour
{
    public GameObject[] king = new GameObject[3];
    public GameObject[] monk = new GameObject[3];
    public GameObject[] haengsu = new GameObject[3];
    public int endPoint = 0;

    public Dialogue kingA;
    public Dialogue kingB;
    public Dialogue kingC;

    public Dialogue monkA;
    public Dialogue monkB;
    public Dialogue monkC;

    public Dialogue haengsuA;
    public Dialogue haengsuB;
    public Dialogue haengsuC;

    private DialogueManager theDM;
    public Canvas ending;

    private bool ended;
   public void King()
    {
        switch (endPoint)
        {
            case 1:
                king[0].SetActive(true);
                end(kingA);
                break;
            case 2:
                king[1].SetActive(true);
                end(kingB);
                break;
            case 3:
                king[2].SetActive(true);
                end(kingC);
                break;

        }
    }
    
    public void Monk()
    {
        switch (endPoint)
        {
            case 1:
                monk[0].SetActive(true);
                end(monkA);
                break;
            case 2:
                monk[1].SetActive(true);
                end(monkB);
                break;
            case 3:
                monk[2].SetActive(true);
                end(monkC);
                break;

        }

    }
    public void HaengSu()
    { 
        switch (endPoint)
        {
            case 1:
                haengsu[0].SetActive(true);
                end(haengsuA);
                break;
            case 2:
                haengsu[1].SetActive(true);
                end(haengsuB);
                break;
            case 3:
                haengsu[2].SetActive(true);
                end(haengsuC);
                break;

        }
    }

    private void Start()
    {
        ended = false;
        black.SetActive(false);
        king[0].SetActive(false);
        king[1].SetActive(false);
        king[2].SetActive(false);
        monk[0].SetActive(false);
        monk[1].SetActive(false);
        monk[2].SetActive(false);
        haengsu[0].SetActive(false);
        haengsu[1].SetActive(false);
        haengsu[2].SetActive(false);
        ending.gameObject.SetActive(true);
        stopkeyinput = true;
        theDM = FindObjectOfType<DialogueManager>();

        setEndPoint();
    }

    private void setEndPoint()
    {
        if (Inventory.instance.FindItem(Constants.basement_monkdiary))
            endPoint = 3;
        else if(Inventory.instance.FindItem(Constants.previous_realEmille) || Inventory.instance.FindItem(Constants.real_realEmille))
        {
            endPoint = 2;
        }
        else
        {
            endPoint = 1;
        }
    }

    public GameObject black;
    private bool stopkeyinput;

        IEnumerator RunFadeOut()
        {
            Color color = black.GetComponent<SpriteRenderer>().color;
            while (color.a > 0.0f)
            {
                stopkeyinput = true;
                color.a -= 0.1f;
                black.GetComponent<SpriteRenderer>().color = color;
                yield return new WaitForSeconds(0.1f);
            }
            if(color.a <= 0.0f)
            {
            stopkeyinput = false;
            }
        }
    private void end(Dialogue _dialogue)
    {
        CanvasNew canvas;
        canvas = FindObjectOfType<CanvasNew>();
        canvas.theEnding();
        black.SetActive(true);
        theDM.ShowDialogue(_dialogue);
        ended = true;
    }

    private bool done = false;
    private void Update()
    {
        if(ended && !DialogueManager.instance.talking && !done)
        {
            done = true;
            StartCoroutine("RunFadeOut");
        }
        if (ended && !stopkeyinput)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("³¡");
                Application.Quit();
            }
        }
    }
}
