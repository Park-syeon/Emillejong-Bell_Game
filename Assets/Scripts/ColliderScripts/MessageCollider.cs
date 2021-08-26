using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageCollider : MonoBehaviour
{
    public Dialogue dialogue;
    
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        dialogue.sentences = new string[] { "아직 들어갈 수 없습니다." };
        DialogueManager.instance.ShowDialogue(dialogue);
    }
}
