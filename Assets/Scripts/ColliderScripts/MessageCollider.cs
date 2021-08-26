using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageCollider : MonoBehaviour
{
    public Dialogue dialogue;
    
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        dialogue.sentences = new string[] { "���� �� �� �����ϴ�." };
        DialogueManager.instance.ShowDialogue(dialogue);
    }
}
