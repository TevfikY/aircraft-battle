using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    [SerializeField] private float speed = 40f;
    private Rigidbody2D rigidBody;
    private bool isAlive = true;
    private Vector2 move;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMovement();
        //rigidBody.AddForce(-rigidBody.velocity*Time.deltaTime);
    }


    private void Update()
    {
        //move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    }

    public void PlayerMovement()
    {
        if (isAlive)
        {
            //rigidBody.AddForce(move*Time.deltaTime*speed,ForceMode2D.Force);
            //rigidBody.velocity = new Vector2(xAxis * speed * Time.deltaTime, 0); 
            if (Input.GetMouseButton(0))
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                
                if (mousePos.y < 1)
                {
                    transform.position = Vector2.MoveTowards(transform.position,new Vector2(mousePos.x,transform.position.y), speed); 
                }
                
            }
            
        }
            
        


    }
    
    
}