using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneUseMessage : MonoBehaviour
{
    public string name;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        SeveralDialogue.instance.SubDialogue(name);
        Destroy(this);
    }
}
