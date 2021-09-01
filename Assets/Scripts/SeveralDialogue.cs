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
        dialogue.sentences = new string[] { "( " + DatabaseManager.instance.itemList[_itemIndex].itemName + " 을 얻었다. )" };
        theDM.ShowDialogue(dialogue);
    }

    public void alreadyItem()
    {
        dialogue.sentences = new string[] { "이미 있는 아이템이다." };  //사실 나오면 뭔가 잘못된거다. bookshelf에서 나온다 쥬륵 하지만 괜찮다!
        theDM.ShowDialogue(dialogue);
    }

    public void CannotEnter()
    {
        dialogue.sentences = new string[] { "(봉닥 스님의 방에 먼저 가 봐야 할 것 같다.)" };
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

    public void yetLetter2()
    {
        dialogue.sentences = new string[] { "(냄새나는 쓰레기통이다. 윽…! 몇 십년 동안 비우지 않은 것처럼 보인다!!!! 멀리하고 싶다.)" };
        theDM.ShowDialogue(dialogue);
    }

    public void Letter2()
    {
        dialogue.sentences = new string[] { "(역시나 냄새나는 쓰레기통이다. 그렇지만 찾아보자)" };
        theDM.ShowDialogue(dialogue);
    }

    public void AfterLetter2()
    {
        dialogue.sentences = new string[] { "(역시나 냄새나는 쓰레기통이다.)" };
        theDM.ShowDialogue(dialogue);
    }
    public void CandleIsNotOn()
    {
        dialogue.sentences = new string[] { "(촛불이 아직 켜져 있지 않다.)" };
        theDM.ShowDialogue(dialogue);
    }
    public void AfterGetDiary4()
    {
        dialogue.sentences = new string[] { "이제 절 입구로 가면 엔딩을 보실 수 있습니다." };
        theDM.ShowDialogue(dialogue);   
    }
    public void Letter1()
    {
        dialogue.sentences = new string[] { "(무려 왕에게서 온 편지이니, 봉닥 스님은 분명 편지를 여러 번 고쳐 써 가며 답장을 썼을 것이다. )" };
        theDM.ShowDialogue(dialogue);
    }
    public void AfterGetDiary3()
    {
        dialogue.sentences = new string[] { "일기장3 뒷부분에서 찢어진 종이조각들이 바람에 흩어지며 날아갔다." };
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
