using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_P2Score : MonoBehaviour
{//BLUE
    public int red;//음수
    public int blue;//양수

    public GameObject Score;
    void Start()
    {
        red = 0;
        blue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Score.GetComponent<S_ScoreManager>().P2red = red;
        Score.GetComponent<S_ScoreManager>().P2blue = blue;
    }
}
