using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_P1Score : MonoBehaviour
{//RED
    public int red;//양수
    public int blue;//음수
    public GameObject Score;
    void Start()
    {
        red = 0;
        blue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Score.GetComponent<S_ScoreManager>().P1red = red;
        Score.GetComponent<S_ScoreManager>().P1blue = blue;
    }
}
