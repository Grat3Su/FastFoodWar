using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class S_ScoreManager : MonoBehaviour
{
    public int P1blue;
    public int P1red;
    public int P2blue;
    public int P2red;

    private float timer;
    public float showtimer;

    public Image ham_icon;
    public Image piz_icon;

    public Image pizza_bar;
    public Image hamburger_bar;

    public Sprite[] win_image;//0 : hamwin / 1 : pizwin
    public Image panelimage; // 판넬 안 이미지

    public float max_Tile;

    public Text timer_text;//타이머 출력
    public Text hamburger_score;//r
    public Text pizza_score;//b

    public Text P1text;
    public Text P2text;


    static int P1score = 0;
    static int P2score = 0;
    private float start_timer;

    public GameObject finishpanel;
    float left_tile;

    void Start()
    {
        timer = 0;
        pizza_bar.fillAmount = 0;
        hamburger_bar.fillAmount = 0;

        P2text.text = P2score.ToString();
        P1text.text = P1score.ToString();

        left_tile = max_Tile;
    }

    void Reset()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;
            P1score = 0;
            P2score = 0;
            SceneManager.LoadScene("MainScene");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void OverCheck()//씬을 로드하고 그거만 바꿀까
    {

        bool game_over_check = false;

        if (P1score == 0 && P2score >= 2)
        {
            game_over_check = true;
        }
        else if (P2score == 0 && P1score >= 2)
        {
            game_over_check = true;
        }
        else if (P2score + P1score >= 3)
        {
            game_over_check = true;
        }
        //else if (P2score + P1score >= 5)
        //{
        //    game_over_check = true;
        //}

        else
        {
            red = P1red + P2red;
            blue = P1blue + P2blue;

            if (red > blue)
            {
                P2score++;
                P2text.text = P2score.ToString();
            }

            if (red < blue)
            {
                P1score++;
                P1text.text = P1score.ToString();
            }
            if (P1score == 0 && P2score >= 2)
            {
                game_over_check = true;
            }
            else if (P2score == 0 && P1score >= 2)
            {
                game_over_check = true;
            }

            else if (P2score + P1score >= 3)
            {
                game_over_check = true;
            }
        }

        if (game_over_check == true)
        {
            Time.timeScale = 0;
            finishpanel.SetActive(true);

            if (P1score < P2score)//여기 잘못됨.  반대로 취급해주세요..
            {
                panelimage.GetComponent<Image>().sprite = win_image[0];

            }
            else if (P1score > P2score)
            {
                panelimage.GetComponent<Image>().sprite = win_image[1];

            }
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void changeColor()
    {
        red = P1red + P2red;
        blue = P1blue + P2blue;

        if (red < blue)
        {
            ham_icon.GetComponent<Image>().color = Color.gray;
            piz_icon.GetComponent<Image>().color = Color.white;
        }
        else if (blue < red)
        {
            ham_icon.GetComponent<Image>().color = Color.white;
            piz_icon.GetComponent<Image>().color = Color.gray;
        }
        else
        {
            ham_icon.GetComponent<Image>().color = Color.white;
            piz_icon.GetComponent<Image>().color = Color.white;
        }
    }

    float red;
    float blue;

    void Update()
    {
        red = P1red + P2red;
        blue = P1blue + P2blue;

        changeColor();

        start_timer += Time.deltaTime;

        if (start_timer > 3.0f)
        {
            if (showtimer > 0)
                timer += Time.deltaTime;
            else
            {
                OverCheck();
                Reset();
            }


            if (timer > 1.0f)
            {
                timer = 0;
                showtimer--;
            }
        }
        if (left_tile > 0)
            left_tile = max_Tile - (red + blue);

        pizza_bar.fillAmount = blue / max_Tile;//max타일으로 나누기... 왜 안되냐
        hamburger_bar.fillAmount = red / max_Tile;

        timer_text.text = showtimer.ToString();
        hamburger_score.text = "RED : " + red.ToString();
        pizza_score.text = "BLUE : " + blue.ToString();//남은 타일, red 점수, blue 점수
    }
}
