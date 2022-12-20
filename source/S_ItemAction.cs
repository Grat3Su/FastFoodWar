using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ItemAction : MonoBehaviour
{
    public int itemtype;// 0: 스피드 다운. 1: 타임 증가 2 : 타임 감소 3 : 부서진 타일

    public GameObject manager;
    Vector2 targetpos;

    public int playerNum;

    public int stepcount;
    float madTimer;
    float Timer;
    Vector2[] TilePos;

    AudioSource[] Item;
    public AudioClip[] item_sound;//0 : add 1 : dec 2 : speed

    // Start is called before the first frame update
    void Start()
    {
        Item = new AudioSource[3];
        for (int i = 0; i < 3; i++)
        {
            Item[i] = gameObject.AddComponent<AudioSource>();
            Item[i].clip = item_sound[i];
            Item[i].loop = false;
        }
        itemtype = 0;

        stepcount = 0;

        int index = 0;
        TilePos = new Vector2[81];
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                TilePos[index] = new Vector2(16.11f - (4.05f * i), 11.88f - (3.56f * j));
                index++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(itemtype == 1)//타겟 스피드 다운
        {
            if(playerNum == 2)
                gameObject.GetComponent<S_P2Move>().moveSpeed += 5;

            if (playerNum == 1)
                gameObject.GetComponent<S_P1Move>().moveSpeed += 5;

            itemtype = 0;
        }
        else if (itemtype == 2)//타임 증가
        {
            manager.GetComponent<S_ScoreManager>().showtimer += 5;
            itemtype = 0;
        }
        else if (itemtype == 3)//타임 감소
        {
            manager.GetComponent<S_ScoreManager>().showtimer -= 3;
            itemtype = 0;
        }
        else if (itemtype == 4)//부서진 타일 밟음. 카운트 세기.
        {
            if (playerNum == 2)
                gameObject.GetComponent<S_P2Move>().moveSpeed = 0;

            if (playerNum == 1)
                gameObject.GetComponent<S_P1Move>().moveSpeed = 0;
                       
            itemtype = 0;
            stepcount++;
        }
        else if(itemtype == 5)
        {
            if (playerNum == 2)
                gameObject.GetComponent<S_P2Move>().moveSpeed = 0;

            if (playerNum == 1)
                gameObject.GetComponent<S_P1Move>().moveSpeed = 0;

            ChangePos();

            itemtype = 0;
        }

        if(stepcount >= 5)
        {//게임 오브젝트 TP. 2초동안.
            madTimer += Time.deltaTime;
            Timer += Time.deltaTime;
            if (Timer > 0.1f)
            {
                Timer = 0;
                int tileindex = Random.Range(0, 81);
                gameObject.transform.position = TilePos[tileindex];
            }
            
            if (madTimer > 2.0f)
            {
                madTimer = 0;
                stepcount = 0;
            }
        }

    }

    void ChangePos()
    {
        int index = Random.Range(0, 8);

        switch(index)
        {
            case 0:
                targetpos = targetpos + new Vector2(4, 3.3f);//RU
                break;

            case 1:
                targetpos = targetpos + new Vector2(4, 0);//RM
                break;

            case 2:
                targetpos = targetpos + new Vector2(4, -3.3f);//RD
                break;

            case 3:
                targetpos = targetpos + new Vector2(0, 3.3f);//MU
                break;

            case 4:
                targetpos = targetpos + new Vector2(0, -3.3f);//MD
                break;

            case 5:
                targetpos = targetpos + new Vector2(-4, 3.3f);//LU
                break;

            case 6:
                targetpos = targetpos + new Vector2(-4, 0);//LM
                break;

            case 7:
                targetpos = targetpos + new Vector2(-4, -3.3f);//LD
                break;
        }
        gameObject.transform.position = targetpos;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "item_attach")
        {
            Item[2].Play();
            Debug.Log("공격!");
            itemtype = 1;
            Destroy(col.gameObject);
        }

        if (col.tag == "item_add_time")
        {
            Item[0].Play();
            Debug.Log("시간 늘리기");
            itemtype = 2;
            Destroy(col.gameObject);
        }

        if (col.tag == "item_dec_time")
        {
            Item[1].Play();
            Debug.Log("시간 줄이기");
            itemtype = 3;
            Destroy(col.gameObject);
        }

        if (col.tag == "brokenTile")//스턴. 카운트 세기.
        {
            Vector2 colpos = col.transform.position;
            Vector2 pluspos = new Vector2(0, 0.7f);
            Debug.Log("금밟았다");
            gameObject.transform.position = colpos + pluspos;
            itemtype = 4;
            Destroy(col.gameObject);
        }

        if(col.tag == "Hole")
        {
            targetpos = col.transform.position;
            Debug.Log("맨홀에 빠졌다");
            itemtype = 5;            
        }
    }
}
