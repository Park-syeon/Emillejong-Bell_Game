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
                //thePlayer.setCanMove(false);  //���� ĳ���� �������̰�
            }
            else if (theBookshelf.getActivated())
            {
                theInventory.setActivated(false);
                //theCamera.transform.position = bookshelf.transform.position; �̤��̰� �ȵǳ׿�
                Debug.Log("�̵���");
                //SYeon ���� ī�޶� bookshelf �ִµ��� �̵��̿�!!
                //thePlayer.setCanMove(false);  //���� ĳ���� �������̰�

            }
            else
            {
                //thePlayer.setCanMove(true);
            }
            if (theBookshelf.getActivated())
            {
                theInventory.setStopKeyInput(true);
            }
            else if (!theBookshelf.getActivated())
            {
                theInventory.setStopKeyInput(false);
                Debug.Log("�ٽ� ���ƿ�");
                //theCamera.transform.position = thePlayer.transform.position; �̤��̰� �ȵǳ׿�
                //SYeon ���� ī�޶� �ٽ� ĳ���� �ִµ��� �̵��̿�!!
            }
        }


    }
}
