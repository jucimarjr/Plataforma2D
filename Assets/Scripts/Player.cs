﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  
    public float JumpForce;
    public float Speed;
   
    public bool isJumping;
    public bool doubleJump;

    private Rigidbody2D rig;
    private Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;

        // correndo para direita
        if(Input.GetAxis("Horizontal") > 0f)
        {
            ani.SetBool("run",true);
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }

        // correndo para esquerda
        if(Input.GetAxis("Horizontal") < 0f)
        {
            ani.SetBool("run",true);
            transform.eulerAngles = new Vector3(0f,180f,0f);
        }

        // parado
        if(Input.GetAxis("Horizontal") == 0f)
        {
            ani.SetBool("run",false);
        }


        
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") )
        {
            if( !isJumping )
            {
                rig.AddForce( new Vector2(0f, JumpForce), ForceMode2D.Impulse );
                doubleJump = true;
                ani.SetBool("jump",true);
            }
            else
            {
                if(doubleJump)
                {
                    rig.AddForce( new Vector2(0f, JumpForce), ForceMode2D.Impulse );
                    doubleJump = false;
                } 
            }
            
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // identificador do layer do Ground
        if (collision.gameObject.layer == 8)
        {
            isJumping = false;
            ani.SetBool("jump",false);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
       // identificador do layer do Ground
        if (collision.gameObject.layer == 8)
        {
            isJumping = true;
        } 
    }

}
