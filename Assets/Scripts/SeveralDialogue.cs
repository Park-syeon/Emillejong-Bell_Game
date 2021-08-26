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
        dialogue.sentences = new string[] { DatabaseManager.instance.itemList[_itemIndex].itemName + " �� �����." };
        theDM.ShowDialogue(dialogue);
    }

    public void alreadyItem()
    {
        dialogue.sentences = new string[] { "�̹� �ִ� �������̴�." };  //��� ������ ���� �߸��ȰŴ�. bookshelf���� ���´� �긤 ������ ������!
        theDM.ShowDialogue(dialogue);
    }

    public void CannotEnter()
    {
        dialogue.sentences = new string[] { "���� �� �� �����ϴ�." };
        theDM.ShowDialogue(dialogue);
    }

    public void PondKey()
    {
        dialogue.sentences = new string[] { "���� �� ���󿡼� ���豸���� ���δ�." };
        theDM.ShowDialogue(dialogue);
    }

    public void Failure()
    {
        dialogue.sentences = new string[] { "(�ƴ� �� ����.)" };
        theDM.ShowDialogue(dialogue);
    }
}
