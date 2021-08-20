using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Requirement : MonoBehaviour
{
    public static Requirement instance;
    #region //싱글톤
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
    #endregion


    private int[] EmilleRoom = new int[3] { 9, 9, 9 };    //0이면 해제된거, 0이 아니면 잠긴거    //에밀레방 들어갈 수 있는지
    private int[] Basement = new int[2] { 9, 9 }; //0이면 해제된거, 0이 아니면 잠긴거
    private bool HalfKeyAble = false;   //연못에서 다섯바퀴 돌아서 반쪽자리 키 사용할 수 있는지
    private bool IsCandleOn = false;    //스님방에 양초가 켜져있는지//그래서 스님의일기장1,2를 사용할 ㅜㅅ 있는지
    private bool IsRealEmille = false;  //이거 왜 있는지 모르겠음

    public bool GetIsCandleOn()
    {
        return IsCandleOn;
    }
    public bool GetIsRealEmille()
    {
        return IsRealEmille;
    }
    public bool IsBasementOpened()
    {
        int i = Basement[0] + Basement[1];
        if (i == 0)
            return true;
        else
            return false;
    }
    public bool getHalfKeyAble()
    {
        return HalfKeyAble;
    }
    public void EmilleRoomUnlock(int _itemID)
    {
        switch (_itemID)
        {
            case Constants.key34:
                EmilleRoom[0] = 0;
                break;
            case 90065:
                EmilleRoom[1] = 0;
                break;
            case 90077:
                EmilleRoom[2] = 0;
                break;
            default:
                break;
        }
    }
    public void BasementUnlock(int _itemID)
    {
        switch (_itemID)
        {
            case Constants.half_key1:
                Basement[0] = 0;
                return;
            case Constants.half_key2:
                Basement[1] = 0;
                return;
        }
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
