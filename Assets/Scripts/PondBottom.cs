using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PondBottom : MonoBehaviour
{
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (MovingObject.instance.transform.position.x > this.transform.position.x)
        {
            Pond.instance.setWalkCheckBottom();
        }
        else
        {
            Pond.instance.setWalkCheckClear();
        }
    }
    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (MovingObject.instance.transform.position.x > this.transform.position.x)
        {
            Pond.instance.setWalkCheckClear();
        }
    }
}
