using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wavePositionOnScene : MonoBehaviour
{
    private Transform cameraPos;
    void Start()
    {
        cameraPos = FindObjectOfType<playerFollower>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =  new Vector3(5,cameraPos.position.y-3,0);
    }
}
