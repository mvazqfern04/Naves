using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float maxima_velocidad = 30f;
    [SerializeField] private float speed = 0.9f;
    private float frenada;
    [SerializeField] private int rotation = 40;


    // Start is called before the first frame update
    void Start()
    {
        frenada = speed*2f;
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            acelerar();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            frenar();
        }
        girar(Input.GetAxisRaw("Horizontal")) ;
    }

    private void acelerar()
    {
        //rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y+speed*Time.deltaTime);
        rb.velocity = Vector2.up*speed;
    }
    private void frenar()
    {
        if( rb.velocity.y>0f)
        {
            //rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y-frenada*Time.deltaTime);
            rb.velocity = Vector2.down*speed;
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
