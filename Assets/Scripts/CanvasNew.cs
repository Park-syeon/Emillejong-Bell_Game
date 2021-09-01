using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasNew : MonoBehaviour
{
    public void theEnding()
    {
        GameObject buttons;
        buttons = GameObject.Find("Buttons");
        buttons.SetActive(false);
    }
    private void Awake()
    {
        DialogueManager.instance.transform.SetParent(this.transform, false);
    }
}
