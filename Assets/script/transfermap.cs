using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transfermap : MonoBehaviour
{
    public string transferMapName; //이동할 맵의 이름
    private MovingObject thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<MovingObject>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            thePlayer.currentMapName = transferMapName;//플레이어의 현재 맵이 이동하고자하는 맵이 됨
            SceneManager.LoadScene(transferMapName);//이동하고자 하는 맵을 로드함.
        }

    }
}
