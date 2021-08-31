using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title2 : MonoBehaviour
{
    public string[] titleStory;
    public Text text;
    public bool talking = false;
    public int count;
    private bool operationKey;

    public GameObject black;
    public GameObject OperationKeyPicture;
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
        if (color.a <= 0.0f)
        {
            stopkeyinput = false;   
        }
    }
    IEnumerator story()
    {
        for (int i = 0; i < titleStory[count].Length; i++)
        {
            text.text += titleStory[count][i];//1글자씩 출력.
            yield return new WaitForSeconds(0.06f);
        }
    }
    public void startStory()
    {
        talking = true;
        black.SetActive(true);
        StopAllCoroutines();
        StartCoroutine("story");
    }
    private void StartOperation()
    {
        OperationKeyPicture.SetActive(true);
        StartCoroutine("RunFadeOut");
        operationKey = true;
    }
    private void Start()
    {
        count = 0;
        talking = false;
        text.text = "";
        black.SetActive(false);
        OperationKeyPicture.SetActive(false);
        operationKey = false;
    }
    private void Update()
    {
        if (talking)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                count++;
                if(count >= titleStory.Length)
                {
                    talking = false;
                    StopAllCoroutines();
                    text.text = "";
                    StartOperation();
                }
                else
                {
                    StopAllCoroutines();
                    text.text = "";
                    StartCoroutine("story");
                }
            }
        }
        else if (operationKey&&!stopkeyinput)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                StopAllCoroutines();
                Title title = FindObjectOfType<Title>();
                title.LoadGame();
            }
        }
    }





}
