using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfKey : MonoBehaviour
{
    public static HalfKey instance;

    #region ?̱???
    private void Awake()    //?̱???!!
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

    public GameObject HalfKey1;
    public GameObject HalfKey2;

    private void Start()
    {
        instance = this;
        HalfKey1.SetActive(false);
        HalfKey2.SetActive(false);
    }

    public void SetActive()
    {
        HalfKey1.SetActive(true);
        HalfKey2.SetActive(true);
    }
}
