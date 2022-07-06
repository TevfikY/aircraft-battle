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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMovement();
        rigidBody.AddForce(-rigidBody.velocity*Time.deltaTime);
    }


    private void Update()
    {
         move = new Vector2( Input.GetAxisRaw("Horizontal"), 0);
        
    }

    public void PlayerMovement()
    {
        if (isAlive)
        {
            rigidBody.AddForce(move*Time.deltaTime*speed,ForceMode2D.Force);
            //rigidBody.velocity = new Vector2(xAxis * speed * Time.deltaTime, 0); 
        }
            
        


    }
    
    
}
