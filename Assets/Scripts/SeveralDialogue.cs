using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeveralDialogue : MonoBehaviour
{
    static public SeveralDialogue instance;
    public Dialogue dialogue;
    [SerializeField]
    public DialogueSub[] subDialogues;
    private DialogueManager theDM;

    private void Start()
    {
        instance = this;
        theDM = FindObjectOfType<DialogueManager>();
    }

    public void GetItem(int _itemID, int _itemIndex)
    {
        if ((_itemID / 10000 == 9 && _itemID < 99000)||_itemID == Constants.basement_monkdiary_die)
        {
            dialogue.sentences = new string[] { DatabaseManager.instance.itemList[_itemIndex].itemDescription };
            theDM.ShowDialogue(dialogue);
        }
        dialogue.sentences = new string[] { "( " + DatabaseManager.instance.itemList[_itemIndex].itemName + " �� �����. )" };
        theDM.ShowDialogue(dialogue);
    }

    public void alreadyItem()
    {
        dialogue.sentences = new string[] { "�̹� �ִ� �������̴�." };  //��� ������ ���� �߸��ȰŴ�. bookshelf���� ���´� �긤 ������ ������!
        theDM.ShowDialogue(dialogue);
    }

    public void CannotEnter()
    {
        dialogue.sentences = new string[] { "(���� ������ �濡 ���� �� ���� �� �� ����.)" };
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

    public void yetLetter2()
    {
        dialogue.sentences = new string[] { "(�������� ���������̴�. ����! �� �ʳ� ���� ����� ���� ��ó�� ���δ�!!!! �ָ��ϰ� �ʹ�.)" };
        theDM.ShowDialogue(dialogue);
    }

    public void Letter2()
    {
        dialogue.sentences = new string[] { "(���ó� �������� ���������̴�. �׷����� ã�ƺ���)" };
        theDM.ShowDialogue(dialogue);
    }

    public void AfterLetter2()
    {
        dialogue.sentences = new string[] { "(���ó� �������� ���������̴�.)" };
        theDM.ShowDialogue(dialogue);
    }
    public void CandleIsNotOn()
    {
        dialogue.sentences = new string[] { "(�к��� ���� ���� ���� �ʴ�.)" };
        theDM.ShowDialogue(dialogue);
    }
    public void AfterGetDiary4()
    {
        dialogue.sentences = new string[] { "���� �� �Ա��� ���� ������ ���� �� �ֽ��ϴ�." };
        theDM.ShowDialogue(dialogue);   
    }
    public void Letter1()
    {
        dialogue.sentences = new string[] { "(���� �տ��Լ� �� �����̴�, ���� ������ �и� ������ ���� �� ���� �� ���� ������ ���� ���̴�. )" };
        theDM.ShowDialogue(dialogue);
    }
    public void AfterGetDiary3()
    {
        dialogue.sentences = new string[] { "�ϱ���3 �޺κп��� ������ ������������ �ٶ��� ������� ���ư���." };
        theDM.ShowDialogue(dialogue);
    }
    public void SubDialogue(string _name)
    {
        for(int i = 0; i< subDialogues.Length; i++)
        {
            if(subDialogues[i].name == _name)
            {
                theDM.ShowDialogue(subDialogues[i]);
            }
        }
    }
}
