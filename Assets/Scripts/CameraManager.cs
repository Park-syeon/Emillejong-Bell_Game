using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    static public CameraManager instance;

    public GameObject target; //카메라가 따라갈 대상.
    public float moveSpeed;//카메라가 얼마나 빠른 속도로 대상을 좇을 것인가
    private Vector3 targetPosition;//대상의 현재 위치 값.


    private bool StopForAMoment;
    public bool getStopMoment()
    {
        return StopForAMoment;
    }
    public void setStop(bool _is)
    {
        StopForAMoment = _is;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        StopForAMoment = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!StopForAMoment)
        {
            if (target.gameObject != null)
            {
                targetPosition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.y);
                this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime);//1초에 movespeed만큼 이동(타임델타타임의 뜻)

            }
        }
    }
}
