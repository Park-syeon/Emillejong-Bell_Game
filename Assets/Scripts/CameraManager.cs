using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    static public CameraManager instance;

    public GameObject target; //ī�޶� ���� ���.
    public float moveSpeed;//ī�޶� �󸶳� ���� �ӵ��� ����� ���� ���ΰ�
    private Vector3 targetPosition;//����� ���� ��ġ ��.


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
                this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime);//1�ʿ� movespeed��ŭ �̵�(Ÿ�ӵ�ŸŸ���� ��)

            }
        }
    }
}
