using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_SwapHead : MonoBehaviour
{
    Animator anim;

    public int char_type;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (char_type == 1)
        {
            if (Input.GetKey(KeyCode.A) == true)
            {
                anim.SetInteger("h_anim", 3);
            }

            else if (Input.GetKey(KeyCode.D) == true)
            {
                anim.SetInteger("h_anim", 3);
            }

            else if (Input.GetKey(KeyCode.S) == true)
            {
                
                anim.SetInteger("h_anim", 6);
            }

            else if (Input.GetKey(KeyCode.W) == true)
            {
                anim.SetInteger("h_anim", 12);
            }
        }
        else if(char_type == 2)
        {
            if (Input.GetKey(KeyCode.LeftArrow) == true)
            {
                anim.SetInteger("p_anim", 3);
            }

            else if (Input.GetKey(KeyCode.RightArrow) == true)
            {
                anim.SetInteger("p_anim", 3);
            }

            else if (Input.GetKey(KeyCode.DownArrow) == true)
            {
                anim.SetInteger("p_anim", 6);
            }

            else if (Input.GetKey(KeyCode.UpArrow) == true)
            {
                anim.SetInteger("p_anim", 12);
            }
        }
        
    }
}
