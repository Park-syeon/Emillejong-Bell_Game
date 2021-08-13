using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    static public MovingObject instance;
    public string currentMapName; //transferMap 스크립트에 있는 transferMapName 변수의 값을 지정
    public float speed;
    public GameManager manager;
    Rigidbody2D rigid;
    float h, v;
    Vector3 dirVec;//현재 바라보고 있는 방향 값을 가진 변수
    private Vector3 vector;
    GameObject scanObject;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }      
    }

    // Update is called once per frame
    void Update()
    {
        //Move Value
        h = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        v = manager.isAction ? 0 : Input.GetAxisRaw("Vertical");
        //Check Button Down & Up
        bool hDown = manager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool vDown = manager.isAction ? false : Input.GetButtonDown("Vertical");
        bool hUp = manager.isAction ? false : Input.GetButtonUp("Horizontal");
        bool vUp = manager.isAction ? false : Input.GetButtonUp("Vertical");

        //Move
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.position.z);

            if(vector.x != 0)
            {
                transform.Translate(vector.x * speed, 0, 0);
            }
            else if(vector.y != 0)
            {
                transform.Translate(0, vector.y * speed, 0);
            }
        }

        //Direction
        if (vDown && v == 1)
            dirVec = Vector3.up;
        else if (vDown && v == -1)
            dirVec = Vector3.down;
        else if (hDown && h == -1)
            dirVec = Vector3.left;
        else if (hDown && h == 1)
            dirVec = Vector3.right;
        if (Input.GetButtonDown("Jump") && scanObject != null)
            manager.Action(scanObject);

    }
    void FixedUpdate()
    {
        //Ray
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0,1,0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
            scanObject = null;
    }
}
