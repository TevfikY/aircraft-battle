using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossPathFinder : MonoBehaviour
{
    private waveConfig waveConfig;
    private List<Transform> waypoints = new List<Transform>();
    private int waypointIndex = 0;
    private enemySpawner _enemySpawner;

    private void Awake()
    {
        _enemySpawner = FindObjectOfType<enemySpawner>();
        
    }

    void Start()
    {
        waveConfig = _enemySpawner.GetCurrentWave();
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
            if (waypointIndex == 0 || waypointIndex == 1 || waypointIndex == 8 || waypointIndex == 9)
            {
               FindObjectOfType<boss_0Turret>().GetComponent<boss_0Turret>().setInPlace(false);
            }
            else
            {
                FindObjectOfType<boss_0Turret>().GetComponent<boss_0Turret>().setInPlace(true); 
            }
            
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
