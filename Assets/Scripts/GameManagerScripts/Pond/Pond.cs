using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pond : MonoBehaviour
{
    public static Pond instance;

    #region ½Ì±ÛÅæ
    private void Awake()    //½Ì±ÛÅæ!!
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

    private bool activated;
    private bool circleDone;

    public int[] WalkCheck = new int[4] { 0, 0, 0, 0 }; //Top, right, bottom, left ¼ø
    // Start is called before the first frame update

    // getsetÇÔ¼ö
    public bool getActivated()
    {
        return activated;
    }
    public bool getCircleDone()
    {
        return circleDone;
    }
    public void setActivated(bool _is)
    {
        activated = _is;
    }
    public void setWalkCheckLeft()
    {
        WalkCheck[3]++;
    }
    public void setWalkCheckBottom()
    {
        WalkCheck[2]++;
    }
    public void setWalkCheckRight()
    {
        WalkCheck[1]++;
    }
    public void setWalkCheckTop()
    {
        WalkCheck[0]++;
    }
    public void setWalkCheckClear()
    {
        for(int i = 0; i < WalkCheck.Length; i++)
        {
            WalkCheck[i] = 0;
        }
    }





    private void CheckCircle()
    {
        for(int i = 0; i < 4; i++)
        {
            if (WalkCheck[i] < 5)
            {
                circleDone = false;
                return;
            }
        }
        circleDone = true;
    }

    void Start()
    {
        activated = true;
        circleDone = false;
        instance = this;
        for (int i = 0; i < 4; i++)
        {
            WalkCheck[i] = 0;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            CheckCircle();
            if (circleDone)
            {
                Requirement.instance.HalfKeyUseActivate(true);
                Debug.Log("¿­¼è±¸¸ÛÀÌ º¸ÀÎ´Ù.");
                activated = false;
            }
        }
    }
}
