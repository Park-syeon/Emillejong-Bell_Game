using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderActiveManager : MonoBehaviour
{
    public static ColliderActiveManager instance;
    private string current_mapname;

    public string temple = "temple";
    public string library = "library";
    public string MonkRoom = "MonkRoom";
    public string pond = "pond";
    public string EmilleRoom = "Á¾ ÀÖ´Â °÷";
    public string basement = "ÁöÇÏ½Ç";

    public string getCurmap()
    {
        return current_mapname;
    }
    public void setCurMap(string _name)
    {
        current_mapname = _name;
    }

    #region ½Ì±ÛÅæ
    private void Awake()    //½Ì±ÛÅæ!!
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
    private void Start()
    {
        current_mapname = temple;
    }
    public void move(string _transferMapName)
    {

            if (FindObjectOfType<ColliderTemple>())
            {
            ColliderTemple.instance.transferMapEvent(_transferMapName);
            }

            if (FindObjectOfType<ColliderLibrary>())
            {
            ColliderLibrary.instance.transferMapEvent(_transferMapName);
        }

            if (FindObjectOfType<ColliderMonkRoom>())
            {
            ColliderMonkRoom.instance.transferMapEvent(_transferMapName);
        }

            if (FindObjectOfType<ColliderBasement>())
            {
            ColliderBasement.instance.transferMapEvent(_transferMapName);
        }

            if (FindObjectOfType<ColliderEmilleRoom>())
            {
            ColliderEmilleRoom.instance.transferMapEvent(_transferMapName);
        }

            if (FindObjectOfType<ColliderPond>())
            {
            ColliderPond.instance.transferMapEvent(_transferMapName);
        }


    }
}
