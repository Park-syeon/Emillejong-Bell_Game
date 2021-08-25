using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManagerWithBS : MonoBehaviour
{
    static public OrderManagerWithBS instance;

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
        instance = this;
        thePlayer = FindObjectOfType<MovingObject>();
        theInventory = FindObjectOfType<Inventory>();
        theBookshelf = FindObjectOfType<Bookshelf>();
        theCamera = FindObjectOfType<Camera>();
    }

    public void move()
    {
        if (DialogueManager.instance.talking)
        {
            theInventory.setActivated(false);
            theInventory.setStopKeyInput(true);
            theBookshelf.setActivated(false);
            thePlayer.notMove = true;
        }
        else if (Bookshelf.instance.getActivated())
        {
            theInventory.setActivated(false);
            CameraManager.instance.setStop(true);
            Vector3 position = new Vector3();
            position.Set(Bookshelf.instance.gameObject.transform.position.x, Bookshelf.instance.gameObject.transform.position.y, Bookshelf.instance.gameObject.transform.position.z + (-66f));
            theCamera.transform.position = position;
            Debug.Log("�̵���");
            //SYeon ���� ī�޶� bookshelf �ִµ��� �̵��̿�!!
            thePlayer.notMove = true;
            theInventory.setStopKeyInput(true);

        }
        else if (theInventory.getActivated())
        {
            thePlayer.notMove = true;
        }

        else
        {
            theInventory.setStopKeyInput(false);
            Vector3 position = new Vector3();
            position.Set(thePlayer.transform.position.x, thePlayer.transform.position.y, thePlayer.gameObject.transform.position.z + (-66f));
            theCamera.transform.position = position;
            CameraManager.instance.setStop(false);
            thePlayer.notMove = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.G) || Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.KeypadEnter))
        {
            move();
        }


    }
}
