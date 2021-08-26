using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEvents : MonoBehaviour
{
    public static ItemEvents instance;
    private void Awake()    //싱글톤!!
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }


    private int itemID;
    AudioManager theAudio;
    public string keySound;
    private int soundNum= 0;

    public Dialogue dialogue;
    private DialogueManager theDM;

    private bool destroy;

    public bool getDestroy()
    {
        return destroy;
    }


    private void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
        theAudio = FindObjectOfType<AudioManager>();
    }

    public void playItemEvent(int _itemID)
    {
        itemID = _itemID;
        destroy = true;
        switch (itemID)
        {
            case Constants.rock:
                ItemRock();
                break;
            case Constants.previous_monkdiary1_ID:
                monkdiary1();
                break;
            case Constants.previous_monkdiary2_ID:
                monkdiary2();
                break;
            case Constants.brick:
                brick();
                break;
            case Constants.half_key1:
                halfKey();
                break;
            case Constants.half_key2:
                halfKey();
                break;
            case Constants.previous_realEmille:
                realEmille();
                break;
            case Constants.key34:
                key346577();
                break;
            case Constants.key65:
                key346577();
                break;
            case Constants.key77:
                key346577();
                break;
            default:
                Debug.LogError("올바르지 않은 콜라이더 할당 값이 있다 고쳐라");
                break;
        }
    }

    private void ItemRock()
    {
        Requirement.instance.Letcandleon(true);
        dialogue.sentences = new string[] { "양초에 불이 켜졌다." };
        theDM.ShowDialogue(dialogue);

    }
    private void monkdiary2()
    {
        if (Requirement.instance.GetIsCandleOn())
        {
            Inventory.instance.GetAnItem(Constants.real_monkdiary2_ID);
            Inventory.instance.RemoveAnItem(itemID);
        }
        else
        {
            destroy = false;
        }
    }
    private void monkdiary1()
    {
        if (Requirement.instance.GetIsCandleOn())
        {
            dialogue.sentences = new string[] { "양초에 비추니 스님의 일기장에서 글씨가 보이기 시작한다." };
            theDM.ShowDialogue(dialogue);
            Inventory.instance.GetAnItem(Constants.real_monkdiary1_ID);
            Inventory.instance.RemoveAnItem(itemID);
            StoryFlow.instance.GotRealMonkDiary1(true);
        }
        else
        {
            destroy = false;
        }
    }
    private void brick()
    {
        Inventory.instance.GetAnItem(Constants.half_key2);
        Inventory.instance.RemoveAnItem(itemID);
    }
    private void key346577()
    {
        Requirement.instance.EmilleRoomUnlock(itemID);
        soundNum = theAudio.Find(keySound);
        theAudio.sounds[soundNum].Play();

        if (Requirement.instance.getEmilleRoomOpen())
        {
            ToEmilleRoom.instance.OpenCollider();
            dialogue.sentences = new string[] { "문이 열렸다." };
            theDM.ShowDialogue(dialogue);
        }
        Inventory.instance.RemoveAnItem(itemID);

    }
    private void realEmille()
    {
        Inventory.instance.GetAnItem(Constants.real_realEmille);
        Inventory.instance.RemoveAnItem(itemID);
    }
    private void halfKey()
    {
        Requirement.instance.BasementUnlock(itemID);
        soundNum = theAudio.Find(keySound);
        theAudio.sounds[soundNum].Play();
        if (Requirement.instance.getIsBasementOpened())
        {
            StoryFlow.instance.SetCanGetIntoBasement(true);
            dialogue.sentences = new string[] { "물이 빠진 연못 한 가운데 문이 보인다." };
            theDM.ShowDialogue(dialogue);
        }
        Inventory.instance.RemoveAnItem(itemID);
    }
}
