using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCamera : MonoBehaviour
{
    public Camera endingCamera;
    private Camera mainCamera;
    public void ChangeCamera()
    {
        Vector3 position = new Vector3(endingCamera.transform.position.x, endingCamera.transform.position.y, endingCamera.transform.position.z);
        endingCamera.enabled = false;
        endingCamera.gameObject.SetActive(false);
        mainCamera = FindObjectOfType<Camera>();
        mainCamera.transform.position = position;
        mainCamera.enabled = true;

        Inventory.instance.gameObject.SetActive(false);
        MovingObject.instance.gameObject.SetActive(false);

    }
    private void Start()
    {
        endingCamera.enabled = true;
    }
}
