using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingUI : MonoBehaviour
{
    public GameObject king;
    public GameObject monk;
    public GameObject haengsu;

    public Canvas ending;

    private bool ended;
   public void King()
    {
        king.SetActive(true);
        end();
    }
    
    public void Monk()
    {
        monk.SetActive(true);
        end();
        
    }
    public void HaengSu()
    {
        haengsu.SetActive(true);
        end();
    }

    private void Start()
    {
        ended = false;
        black.SetActive(false);
        king.SetActive(false);
        monk.SetActive(false);
        haengsu.SetActive(false);
        ending.gameObject.SetActive(true);
        stopkeyinput = true;
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
    private void end()
    {
        ended = true;
        ending.gameObject.SetActive(false);
        black.SetActive(true);
        StartCoroutine("RunFadeOut");
    }

    private void Update()
    {
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
