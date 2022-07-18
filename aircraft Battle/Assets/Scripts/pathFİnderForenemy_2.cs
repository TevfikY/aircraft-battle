using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathFİnderForenemy_2 : MonoBehaviour
{
    
    private waveConfig waveConfig;
    private List<Transform> waypoints = new List<Transform>();
    private int waypointIndex = 0;
    private EnemySpawner _EnemySpawner;

    private void Awake()
    {
        _EnemySpawner = FindObjectOfType<EnemySpawner>();
        
    }

    void Start()
    {
        waveConfig = _EnemySpawner.GetCurrentWave();
        waypoints = waveConfig.GetWayPoints();
        transform.position = waypoints[waypointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPath();
    }
    
    
    void FollowPath()
    {
        
        if (waypointIndex < waypoints.Count)
        {
            Vector3 target = waypoints[waypointIndex].position;
            
            float speed = waveConfig.GetMoveSpeed() ;
            
            
            transform.position = Vector2.MoveTowards(transform.position,target,speed* Time.deltaTime);
            
            if ((Vector2)transform.position == (Vector2)target)
            {
                waypointIndex++;
                
            }
        }
        else
        {
            waypointIndex = 1;
            
        }
        
    }
}
