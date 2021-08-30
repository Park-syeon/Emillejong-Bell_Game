using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToEmilleRoom : MonoBehaviour
{
    static public ToEmilleRoom instance;

    #region ΩÃ±€≈Ê
    private void Awake()    //ΩÃ±€≈Ê!!
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }
    #endregion

    public GameObject[] physicCollider;

    public void OpenCollider()
    {
        for (int i = 0; i < physicCollider.Length; i++)
        {
            physicCollider[i].SetActive(false);
        }
    }

    private void Start()
    {
        instance = this;
        for(int i = 0; i< physicCollider.Length; i++)
        {
            physicCollider[i].SetActive(true);
        }
    }
}
