using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    [SerializeField] private float speed = 40f;
    private Rigidbody2D rigidBody;
    private bool isAlive = true;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMovement();
    }


    public void PlayerMovement()
    {
        if (isAlive)
        {
            float xAxis = Input.GetAxisRaw("Horizontal");
            rigidBody.velocity = new Vector2(xAxis * speed * Time.deltaTime, 0); 
        }
            
        


    }
    
    
}
