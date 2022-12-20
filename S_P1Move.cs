using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_P1Move : MonoBehaviour
{
    // 플레이어 1 움직임 : WASD
    public float moveSpeed;
    public Sprite tile;
    private SpriteRenderer render;
    private bool tcol = false;

    Animator anim;

    private float timer;
    private float speed;
    bool attach;
    float attachTimer;
    public float attachDelayTime = 1.5f;

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

        if (attach == true)
        {
            attachTimer += Time.deltaTime;

            if (attachTimer > attachDelayTime)
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

        if (Input.GetKey(KeyCode.A) == true)
        {
            moveVelocity = Vector3.left;
            anim.SetInteger("h_anim", 3);
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }

        else if (Input.GetKey(KeyCode.D) == true)
        {
            moveVelocity = Vector3.right;
            anim.SetInteger("h_anim", 3);
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }

        else if (Input.GetKey(KeyCode.S) == true)
        {
            moveVelocity = Vector3.down;
            anim.SetInteger("h_anim", 6);
        }

        else if (Input.GetKey(KeyCode.W) == true)
        {
            moveVelocity = Vector3.up;
            anim.SetInteger("h_anim", 12);
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
