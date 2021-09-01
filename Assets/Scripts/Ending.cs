using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    private bool activated = false;
    public Dialogue dialogue;
    private DialogueManager theDM;
    public void setActivated(bool _is)
    {
        activated = _is;
        if (activated)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        activated = false;
        theDM = FindObjectOfType<DialogueManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        theDM.ShowDialogue(dialogue);
        activated = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        activated = false;
    }
    private void Update()
    {
        if (activated)
        {
            if (!theDM.talking)
            {
                if (Input.GetKeyDown(KeyCode.G))
                {
                    Debug.Log("»Ï»Ï");
                    ColliderActiveManager.instance.move("Ending");
                    Camera mainCamera = FindObjectOfType<Camera>();
                    mainCamera.enabled = false;
                    MovingObject.instance.gameObject.SetActive(false);
                    SceneManager.LoadScene("Ending");
                }
            }
        }
    }
}
