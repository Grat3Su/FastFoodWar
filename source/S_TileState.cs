using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_TileState : MonoBehaviour
{

    public int mode;//0 : 기본 / 1 : R  / 2 : B
    bool col_red;
    bool col_blue;
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        col_red = false;
        col_blue = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (col_red)
        {
            if (mode != 1)//타일이 이미 빨강
            {
                target.GetComponent<S_P1Score>().red += 1;
            }

            if (mode == 2)
            {
                target.GetComponent<S_P1Score>().blue -= 1;
            }

            mode = 1;
            col_red = false;
        }

        if (col_blue)
        {
            if (mode != 2)//타일이 이미 파랑
            {
                target.GetComponent<S_P2Score>().blue += 1;
            }

            if (mode == 1)
            {
                target.GetComponent<S_P2Score>().red -= 1;
            }

            mode = 2;
            col_blue = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)//태그 읽기
    {
        if (col.tag == "player1")
        {
            target = col.gameObject;
            Debug.Log("red 충돌");
            col_red = true;
        }
        if (col.tag == "player2")
        {
            target = col.gameObject;
            Debug.Log("blue 충돌");
            col_blue = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        col_red = false;
        col_blue = false;

        Debug.Log("빠져나감");
    }
}
