using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToEmilleRoom : MonoBehaviour
{
    static public ToEmilleRoom instance;

    #region �̱���
    private void Awake()    //�̱���!!
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

    public GameObject physicCollider;

    public void OpenCollider()
    {
        physicCollider.SetActive(false);
    }

    private void Start()
    {
        instance = this;
        physicCollider.SetActive(true);

    }
}
