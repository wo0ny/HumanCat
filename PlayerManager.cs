using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : PlayerAction
{
   
    public string currentMapName;
    private float lastHorizontal = 0;
    SpriteRenderer spriteRenderer;
    float detect_range=1.2f;
    GameObject scanObject;
    
    
    public Vector3 startPosition = new Vector3(1, 1, -1);

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    void Start()
    {
        transform.position = startPosition;
        if (instance == null)
        {
            rigid = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>(); 
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

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

        //Check Horizontal Move
        if (hDown || vUp)
        {
            isHorizonMove = true;
            if (h != 0) lastHorizontal = h; // 수평 입력이 있으면 마지막 방향 갱신
        }
        else if (vDown || hUp)
        {
            isHorizonMove = false;
        }
        
        //Direction
        if (vDown && v == 1)
            dirVec = Vector3.up;
        else if (vDown && v == -1)
            dirVec = Vector3.down;
        else if (hDown && h == -1)
            dirVec = Vector3.left;
        else if (vDown && v == 1)
            dirVec = Vector3.right;
        
        //Scan Object
        if(Input.GetButtonDown("Jump") && scanObject != null)
            manager.Action(scanObject);  
            //Debug.Log("This is : " + scanObject);
        
    }

    void FixedUpdate()
    {

        anim.SetFloat("DirH", h);
        anim.SetFloat("DirV", v);
        // 애니메이션 Walking 상태 업데이트
        
        bool isMoving = h != 0 || v != 0;
        anim.SetBool("Walking", isMoving);
        //if (lastHorizontal != 0) // 마지막으로 눌린 수평 방향키가 있을 경우에만 DirH 파라미터 업데이트
        {
            anim.SetFloat("DirH", lastHorizontal);
        }
        //Move
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rigid.velocity = moveVec * runSpeed;
        }
        else
            rigid.velocity = moveVec * normalSpeed;
        
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

