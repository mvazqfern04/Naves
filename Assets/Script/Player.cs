using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.U2D;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 0f;
    [SerializeField] private float velMax;
    [SerializeField] private float rotacion;

    private bool isAlive = true;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            move();
        }
    }

    private void move()
    {
        float rotacionDirect = Input.GetAxisRaw("Horizontal");
        float movement = Input.GetAxisRaw("Vertical");

        if (rotacionDirect<0)
        {
            transform.Rotate(0f, 0f, rotacion*Time.deltaTime, Space.Self);
        }
        else if (rotacionDirect>0)
        {
            transform.Rotate(0f, 0f, -rotacion*Time.deltaTime, Space.Self);
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
