using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    static public MovingObject instance;
    public string currentMapName; //transferMap 스크립트에 있는 transferMapName 변수의 값을 지정
    public string pastMapName;
    public float speed;
    private Vector3 vector;
    //shift 키를 누르면 빨리 달릴 수 있도록 함.
    public float runSpeed;
    private float applyRunSpeed;
    private bool applyRunFlag = false;
    //tile 단위로 캐릭터가 움직이도록 함.
    public int walkCount;
    private int currentWalkCount;
    //캐릭터가 움직일 수 없도록 하는데 관여하는 변수
    public bool notMove = false;//notMove 변수 선언했고

    private bool canMove = true;
    private Animator animator;

    public string walkSound;
    private int walk = 0;
    private AudioManager theaudio;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        theaudio = FindObjectOfType<AudioManager>();
        walk = theaudio.Find(walkSound);
    }
    IEnumerator MoveCoroutine()
    {
        while (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0 && !notMove)//!notMove 추가했고
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                applyRunSpeed = runSpeed;
                applyRunFlag = true;
            }
            else
            {
                applyRunSpeed = 0;
                applyRunFlag = false;
            }
            vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.position.z);

            if (vector.x != 0)
                vector.y = 0;

            animator.SetFloat("DirX", vector.x);
            animator.SetFloat("DirY", vector.y);
            animator.SetBool("Walking", true);

            while (currentWalkCount < walkCount)
            {
                if (vector.x != 0)
                {
                    transform.Translate(vector.x * (speed + applyRunSpeed), 0, 0);
                }
                else if (vector.y != 0)
                {
                    transform.Translate(0, vector.y * (speed + applyRunSpeed), 0);
                }
                if (applyRunFlag)
                    currentWalkCount++;
                currentWalkCount++;
                yield return new WaitForSeconds(0.01f);
            }
            currentWalkCount = 0;
        }
        animator.SetBool("Walking", false);
        canMove = true;
    }

    IEnumerator WalkSound()
    {
        while (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0 && !notMove)
        {
            theaudio.sounds[walk].Play();
            yield return new WaitForSeconds(0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Move
        if (canMove && !notMove)//!notMove 추가했고
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                StopAllCoroutines();
                canMove = false;
                StartCoroutine(MoveCoroutine());
                StartCoroutine(WalkSound());
            }
        }

    }


}