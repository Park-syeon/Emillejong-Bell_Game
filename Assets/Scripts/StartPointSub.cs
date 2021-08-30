using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPointSub : MonoBehaviour
{
    public string startPoint;//맵의 이동, 플레이어가 시작됨
    public string pastMap;
    private MovingObject thePlayer;
    private CameraManager theCamera;
    // Start is called before the first frame update
    void Start()
    {
        theCamera = FindObjectOfType<CameraManager>();
        thePlayer = FindObjectOfType<MovingObject>();
        if (startPoint == thePlayer.currentMapName && pastMap == thePlayer.pastMapName)
        {
            theCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, theCamera.transform.position.z);
            thePlayer.transform.position = this.transform.position;
        }
    }
}
