using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_5DeathFix : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void dead()
    {
        
            for (int i = 0; i < 2; i++)
            {
                gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    
}
