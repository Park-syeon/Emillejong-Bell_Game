using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookshelfActive : ItemAcquire
{
    /*
     connectitemID 넣을 필요 없음! GIcon 항목 빼도 됨
    빼려 할 때는 ItemAcquire.cs 파일에 protected void OntriggerEnter2D -> protected virtual void OntriggerEnter2D 로 바꾸고
    이 파일에
    protected override void OntriggerEnter2D(Collider2D collision)
    {
        IsTriggerActivated = true;
    }
    추가해주기
     */
    protected override void Do()
    {
        Bookshelf.instance.setActivated(true);
    }
}
