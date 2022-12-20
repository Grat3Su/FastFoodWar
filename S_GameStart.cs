using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_GameStart : MonoBehaviour
{
    //1.2.3 스프라이트 받아서 1초마다 이미지 바꾸기.
    //0 : 3 / 1 : 2 / 2 : 1

    public Sprite[] number;
    private float timer;
    public Image counter;
   
    GameObject timeimage;
    int index;
    void Start()
    {
        timer = 0;
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer <= 1.0f)
        {
            index = 0;
            counter.GetComponent<Image>().sprite = number[index];
        }
        else if (timer <= 2.0f)
        {
            index = 1;
            counter.GetComponent<Image>().sprite = number[index];
        }
        else if (timer <= 3.0f)
        {
            index = 2;
             counter.GetComponent<Image>().sprite = number[index];
        }
        else
            counter.gameObject.SetActive(false);
        
    }
}
