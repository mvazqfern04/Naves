using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float maxima_velocidad = 30f;
    [SerializeField] private float vel_ace= 0.5f;
    [SerializeField] private float vel_act = 0f;
    private float frenada;
    [SerializeField] private int rotation = -3;


    // Start is called before the first frame update
    void Start()
    {
        frenada = vel_ace*2f;
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            acelerar();
        }
        if (Input.GetKey(KeyCode.S))
        {
            frenar();
        }
        girar(Input.GetAxisRaw("Horizontal")) ;
        vel_act=rb.velocity.y;
    }

    private void acelerar()
    {
        if (rb.velocity.y<=maxima_velocidad)
        {
            rb.velocity = rb.transform.up*vel_ace;
            //rb.transform.Translate();
        }
    }
    private void frenar()
    {
        if( rb.velocity.y>0f)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {       
            rb.velocity =Vector2.zero;
        }
    }

    private void girar(float direccion)
    {
        if (direccion==0)
        {
            return;
        }
        gameObject.transform.Rotate(0,0,direccion*rotation);
    }
}
