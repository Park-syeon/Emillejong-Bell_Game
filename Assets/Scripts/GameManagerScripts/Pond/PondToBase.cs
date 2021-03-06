using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PondToBase : MonoBehaviour
{
    static public PondToBase instance;

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

    public GameObject PondCollider;
    public GameObject ToBaseCollider;

    public void OpenCollider()
    {
        PondCollider.SetActive(false);
    }
    public void OpenBasement()
    {
        ToBaseCollider.SetActive(true);
    }

    private void Start()
    {
        instance = this;
        PondCollider.SetActive(true);
        ToBaseCollider.SetActive(false);
    }
}
