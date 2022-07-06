using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config",fileName = "New Wave Config")]
public class waveConfig : ScriptableObject
{
    // Start is called before the first frame update
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private Transform pathPrefab;
    [SerializeField] private float moveSpeed = 5f;
    
    

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public Transform getStartingPoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWayPoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in pathPrefab)
        {
            waypoints.Add(child);
            
        }

        return waypoints;

    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }

    public int getEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    
}
