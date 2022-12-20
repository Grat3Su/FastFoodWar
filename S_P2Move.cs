using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_P2Move : MonoBehaviour
{
    // 플레이어 2 움직임 : 방향키
    public float moveSpeed;
    public Sprite tile;
    private SpriteRenderer render;
    private bool tcol = false;
    private float speed;
    private float timer;
    bool attach;
    float attachTimer;
    public float attachDelayTime = 1.5f;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        speed = moveSpeed;
        attach = false;
    }

    void Update()
    {
        SetMove();
        if (tcol == true)
        {
            render.sprite = tile;
        }
        AttachCheck();
    }

    void AttachCheck()
    {
        if (speed != moveSpeed)
            attach = true;

        if(attach == true)
        {
            attachTimer += Time.deltaTime;

            if(attachTimer>attachDelayTime)
            {
                moveSpeed = speed;
                attach = false;
                attachTimer = 0;
            }
        }
    }

    void SetMove()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            moveVelocity = Vector3.left;
            anim.SetInteger("p_anim", 3);
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }

        else if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            moveVelocity = Vector3.right;
            anim.SetInteger("p_anim", 3);
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }

        else if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            moveVelocity = Vector3.down;
            anim.SetInteger("p_anim", 6);
        }

        else if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            moveVelocity = Vector3.up;
            anim.SetInteger("p_anim", 12);
        }

        timer += Time.deltaTime;
        if (timer > 3.0f)
        {
            transform.position += moveVelocity * moveSpeed * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Tile")
        {
            Debug.Log("타일 충돌");
            render = col.GetComponent<SpriteRenderer>();
            tcol = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Tile")
        {
            tcol = false;
        }
    }
}
