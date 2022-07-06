using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
     private waveConfig currentWave;
     private float timeBetweenWaves = 0f;

    [SerializeField] private List<waveConfig> waveConfigs;
    void Start()
    {
        StartCoroutine(spawn());
    }

   
    IEnumerator spawn()
    {
        foreach (waveConfig wave in waveConfigs)
        {
            currentWave = wave;
            for (int i = 0; i < currentWave.getEnemyCount(); i++)
            {
                GameObject enemy =  Instantiate(currentWave.GetEnemyPrefab(0), currentWave.getStartingPoint().position, Quaternion.identity);
                enemy.transform.localScale = new Vector3(1, -1, 1);
                yield return new WaitForSeconds(2f);
            }

            yield return new WaitForSeconds(timeBetweenWaves);
        }
        
        
    }

    public waveConfig GetCurrentWave()
    {
        return currentWave;
    }
    void Update()
    {
        
    }
}
