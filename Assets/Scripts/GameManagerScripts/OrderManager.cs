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
                //thePlayer.setCanMove(false);  //여긴 캐릭터 못움직이게
            }
            else if (theBookshelf.getActivated())
            {
                theInventory.setActivated(false);
                //theCamera.transform.position = bookshelf.transform.position; ㅜㅜ이거 안되네여
                Debug.Log("이동함");
                //SYeon 여기 카메라 bookshelf 있는데로 이동이요!!
                //thePlayer.setCanMove(false);  //여긴 캐릭터 못움직이게

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
                Debug.Log("다시 돌아옴");
                //theCamera.transform.position = thePlayer.transform.position; ㅜㅜ이거 안되네여
                //SYeon 여기 카메라 다시 캐릭터 있는데로 이동이요!!
            }
        }


    }
}
