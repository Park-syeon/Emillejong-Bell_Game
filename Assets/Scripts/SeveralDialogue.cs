using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeveralDialogue : MonoBehaviour
{
    static public SeveralDialogue instance;
    public Dialogue dialogue;
    private DialogueManager theDM;

    private void Start()
    {
        instance = this;
        theDM = FindObjectOfType<DialogueManager>();
    }

    public void GetItem(int _itemID, int _itemIndex)
    {
        if (_itemID / 10000 == 9 && _itemID != Constants.basement_monkdiary)
        {
            dialogue.sentences = new string[] { DatabaseManager.instance.itemList[_itemIndex].itemDescription };
            theDM.ShowDialogue(dialogue);
        }
        dialogue.sentences = new string[] { DatabaseManager.instance.itemList[_itemIndex].itemName + " 을 얻었다." };
        theDM.ShowDialogue(dialogue);
    }

    public void alreadyItem()
    {
        dialogue.sentences = new string[] { "이미 있는 아이템이다." };  //사실 나오면 뭔가 잘못된거다. bookshelf에서 나온다 쥬륵 하지만 괜찮다!
        theDM.ShowDialogue(dialogue);
    }

    public void CannotEnter()
    {
        dialogue.sentences = new string[] { "아직 들어갈 수 없습니다." };
        theDM.ShowDialogue(dialogue);
    }

    public void PondKey()
    {
        dialogue.sentences = new string[] { "연못 옆 석상에서 열쇠구멍이 보인다." };
        theDM.ShowDialogue(dialogue);
    }

    public void Failure()
    {
        dialogue.sentences = new string[] { "(아닌 것 같다.)" };
        theDM.ShowDialogue(dialogue);
    }
}
