using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    private MovingObject thePlayer;
    private Inventory theInventory;
    private Bookshelf theBookshelf;
    private Camera theCamera;

    public GameObject bookshelf;

    public void setCanMove()
    {
        thePlayer.notMove = true;
    }

    public void Move()
    {
        thePlayer.notMove = false;
    }
    //setCanMove, Move �Լ� ��������ϴ�
    void Start()
    {
        thePlayer = FindObjectOfType<MovingObject>();
        theInventory = FindObjectOfType<Inventory>();
        theBookshelf = FindObjectOfType<Bookshelf>();
        theCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.G))
        {
            if (theInventory.getActivated())
            {
                thePlayer.notMove = true;
            }
            else if (theBookshelf.getActivated())
            {
                theInventory.setActivated(false);
                CameraManager.instance.setStop(true);
                theCamera.transform.position = bookshelf.transform.position;
                Debug.Log("�̵���");
                //SYeon ���� ī�޶� bookshelf �ִµ��� �̵��̿�!!
                thePlayer.notMove = true;

            }
            else
            {
                thePlayer.notMove = false;
            }

            if (theBookshelf.getActivated())
            {
                theInventory.setStopKeyInput(true);
            }
            else if (!theBookshelf.getActivated())
            {
                theInventory.setStopKeyInput(false);
                Debug.Log("�ٽ� ���ƿ�");
                CameraManager.instance.setStop(false);
            }
        }


    }
}
