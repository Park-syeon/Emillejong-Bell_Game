using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Requirement : MonoBehaviour
{
    public static Requirement instance;
    #region //�̱���
    private void Awake()    //�̱���!!
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
    #endregion


    private int[] EmilleRoom = new int[3] { 9, 9, 9 };    //0�̸� �����Ȱ�, 0�� �ƴϸ� ����    //���з��� �� �� �ִ���
    private int[] Basement = new int[2] { 9, 9 }; //0�̸� �����Ȱ�, 0�� �ƴϸ� ����
    private bool isBasementOpened;
    private bool HalfKeyAble = false;   //�������� �ټ����� ���Ƽ� �����ڸ� Ű ����� �� �ִ���
    private bool IsCandleOn = false;    //���Թ濡 ���ʰ� �����ִ���//�׷��� �������ϱ���1,2�� ����� �̤� �ִ���
    private bool IsRealEmille = false;  //�̰� �� �ִ��� �𸣰���
    private bool IsEmilleRoomOpened = false;

    public bool GetIsCandleOn()
    {
        return IsCandleOn;
    }
    public bool GetIsRealEmille()
    {
        return IsRealEmille;
    }
    public bool getIsBasementOpened()
    {
        return isBasementOpened;
    }
    public bool getHalfKeyAble()
    {
        return HalfKeyAble;
    }
    public bool getEmilleRoomOpen()
    {
        return IsEmilleRoomOpened;
    }
    public void EmilleRoomUnlock(int _itemID)
    {
        switch (_itemID)
        {
            case Constants.key34:
                EmilleRoom[0] = 0;
                break;
            case Constants.key65:
                EmilleRoom[1] = 0;
                break;
            case Constants.key77:
                EmilleRoom[2] = 0;
                break;
            default:
                break;
        }
        if(EmilleRoom[0]+EmilleRoom[1]+EmilleRoom[2] == 0)
        {
            IsEmilleRoomOpened = true;
        }
    }
    public void BasementUnlock(int _itemID)
    {
        switch (_itemID)
        {
            case Constants.half_key1:
                Basement[0] = 0;
                break;
            case Constants.half_key2:
                Basement[1] = 0;
                break;
        }
        if (Basement[0] + Basement[1] == 0)
            isBasementOpened = true;
    }
    public void HalfKeyUseActivate(bool _is)
    {
        HalfKeyAble = _is;
        if (_is)
        {
            HalfKey.instance.SetActive();
        }
    }
    public void Letcandleon(bool _is)
    {
        IsCandleOn = _is;
    }
    public void Letrealemille(bool _is)
    {
        IsRealEmille = _is;
    }


    public void Start()
    {
        instance = this;
    }

}
