using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.U2D;
using UnityEngine;

public class Player : MonoBehaviour
{
<<<<<<< HEAD
    private float speed = 0f;
    [SerializeField] private float velMax;
    [SerializeField] private float rotacion;

    private bool isAlive = true;
=======
    private Rigidbody2D rb;
    [SerializeField] private float maxima_velocidad = 30f;
    [SerializeField] private float vel_ace= 0.5f;
    [SerializeField] private float vel_act = 0f;
    private float frenada;
    [SerializeField] private int rotation = -3;
>>>>>>> 0777d554187dda61d3679093c4133ca5891cb6a2


    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD

=======
        frenada = vel_ace*2f;
        rb= GetComponent<Rigidbody2D>();
>>>>>>> 0777d554187dda61d3679093c4133ca5891cb6a2
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            move();
        }
<<<<<<< HEAD
=======
        if (Input.GetKey(KeyCode.S))
        {
            frenar();
        }
        girar(Input.GetAxisRaw("Horizontal")) ;
        vel_act=rb.velocity.y;
>>>>>>> 0777d554187dda61d3679093c4133ca5891cb6a2
    }

    private void move()
    {
<<<<<<< HEAD
        float rotacionDirect = Input.GetAxisRaw("Horizontal");
        float movement = Input.GetAxisRaw("Vertical");

        if (rotacionDirect<0)
        {
            transform.Rotate(0f, 0f, rotacion*Time.deltaTime, Space.Self);
        }
        else if (rotacionDirect>0)
        {
            transform.Rotate(0f, 0f, -rotacion*Time.deltaTime, Space.Self);
=======
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
>>>>>>> 0777d554187dda61d3679093c4133ca5891cb6a2
        }
        else
        {
            //Idle
        }
        //Chad
        if (movement == 0f)
        {
            //No toca nada
            if (speed > 0f)
            {
                speed-=0.05f;
            }
        }
        //Para Alante
        else if (movement >= 1f)
        {
            //Acelera
            if (speed < velMax)
            {
                speed += 0.5f;
            }
            //TOPE
            else if (speed >= velMax)
            {
                speed=velMax;
            }
        }
        //Para Atras
        else if (movement <=-1f)
        {
            //Quieto
            if (speed <=0f)
            {
                speed=0f;
            }
            //Freno
            else if (speed >0)
            {
                speed -= 0.75f;
            }
        }
        transform.Translate(Vector3.up*speed*Time.deltaTime);

        //Debug
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position = new Vector3(0, 0, 0);
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "limite")
        {
            if (collision.transform.position.x == 0)
            {
                if (collision.transform.position.y >0)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y*-1+0.1f, 0);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y*-1-0.1f, 0);
                }
            }
            else
            {
                if (collision.transform.position.x >0)
                {
                    transform.position = new Vector3(transform.position.x*-1+0.1f, transform.position.y, 0);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x*-1-0.1f, transform.position.y, 0);
                }
            }
        }
    }
}
