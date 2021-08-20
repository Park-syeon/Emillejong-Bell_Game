using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PondRight : MonoBehaviour
{
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (MovingObject.instance.transform.position.y > this.transform.position.y)
        {
            Pond.instance.setWalkCheckRight();
        }
        else
        {
            Pond.instance.setWalkCheckClear();
        }
    }
    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (MovingObject.instance.transform.position.y > this.transform.position.y)
        {
            Pond.instance.setWalkCheckClear();
        }
    }
}
