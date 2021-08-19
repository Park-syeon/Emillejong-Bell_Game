using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PondLeft : MonoBehaviour
{
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (MovingObject.instance.transform.position.y < this.transform.position.y)
        {
            Pond.instance.setWalkCheckLeft();
        }
        else
        {
            Pond.instance.setWalkCheckClear();
        }
    }
    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (MovingObject.instance.transform.position.y < this.transform.position.y)
        {
            Pond.instance.setWalkCheckClear();
        }
    }
}
