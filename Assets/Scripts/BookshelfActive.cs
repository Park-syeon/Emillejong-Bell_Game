using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookshelfActive : ItemAcquire
{
    /*
     connectitemID ���� �ʿ� ����! GIcon �׸� ���� ��
    ���� �� ���� ItemAcquire.cs ���Ͽ� protected void OntriggerEnter2D -> protected virtual void OntriggerEnter2D �� �ٲٰ�
    �� ���Ͽ�
    protected override void OntriggerEnter2D(Collider2D collision)
    {
        IsTriggerActivated = true;
    }
    �߰����ֱ�
     */
    protected override void Do()
    {
        Bookshelf.instance.setActivated(true);
    }
}
