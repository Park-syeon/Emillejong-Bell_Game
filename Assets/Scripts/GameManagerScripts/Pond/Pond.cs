using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pond : MonoBehaviour
{
    public static Pond instance;

    private bool activated;
    private bool circleDone;

    private int[] WalkCheck = new int[4] { 0, 0, 0, 0 }; //Top, right, bottom, left 순
    // Start is called before the first frame update

    // getset함수
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
                Debug.Log("열쇠구멍이 보인다.");
                activated = false;
            }
        }
    }
}
