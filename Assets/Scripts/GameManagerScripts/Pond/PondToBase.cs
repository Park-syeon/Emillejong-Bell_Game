using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PondToBase : MonoBehaviour
{
    static public PondToBase instance;

    public GameObject Collider;
    public GameObject ToBaseCollider;

    public void OpenCollider()
    {
        Collider.SetActive(false);
    }
    public void OpenBasement()
    {
        ToBaseCollider.SetActive(true);
    }

    private void Start()
    {
        instance = this;
        Collider.SetActive(true);
        ToBaseCollider.SetActive(false);
    }
}
