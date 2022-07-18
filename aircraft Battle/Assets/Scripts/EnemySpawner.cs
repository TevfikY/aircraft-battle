using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    private waveConfig currentWave;
        private float timeBetweenWaves = 0f;
        [SerializeField] private float timeBetweenEnemeies = 0.5f;
       [SerializeField] private List<waveConfig> waveConfigs;
       [SerializeField] private List<waveConfig> waveConfigs2;
       [SerializeField] private List<waveConfig> waveConfigs3;
       [SerializeField] private List<waveConfig> waveConfigs4;
       private List<waveConfig> deletedWaves= new List<waveConfig>();
       private int phaze = 0;
       public bool allEnemiesAlive = true;
       private List<waveConfig> selectedWaves = new List<waveConfig>();
       private int enemyCount = 0;
       void Start()
       {
           StartCoroutine(spawn());
           
       }
   
      
       IEnumerator spawn()
       {
           if (phaze == 0 )
           {   
               selectedWaves.Clear();
               int firstRandom = Random.Range(0, waveConfigs.Count);

               deletedWaves.Add(waveConfigs[firstRandom]);
               selectedWaves.Add(waveConfigs[firstRandom]);
               
               waveConfigs.Remove(waveConfigs[firstRandom]);
               int secondRandom = Random.Range(0, waveConfigs.Count);
               selectedWaves.Add(waveConfigs[secondRandom]);
               enemyCount += selectedWaves[0].getEnemyCount();
               enemyCount += selectedWaves[1].getEnemyCount();
               foreach (waveConfig wave in deletedWaves)
               {
                   waveConfigs.Add(wave);
               }
               deletedWaves.Clear();
               foreach (waveConfig wave in selectedWaves)
               {
                   
                   currentWave = wave;
                   for (int i = 0; i < currentWave.getEnemyCount(); i++)
                   {
                       GameObject enemy = Instantiate(currentWave.GetEnemyPrefab(i),
                           currentWave.getStartingPoint().position, Quaternion.identity);
                        
                       
                       yield return new WaitForSeconds(timeBetweenEnemeies);
                   }

                   

                   yield return new WaitForSeconds(timeBetweenWaves);
               }
           }else if (phaze == 1)
           {
               selectedWaves.Clear();
               int firstRandom = Random.Range(0, waveConfigs2.Count);
               selectedWaves.Add(waveConfigs2[0]);
               foreach (waveConfig wave in selectedWaves)
               {

                   currentWave = wave;
                   for (int i = 0; i < 1; i++)
                   {
                       GameObject enemy = Instantiate(currentWave.GetEnemyPrefab(i),
                           currentWave.getStartingPoint().position, Quaternion.identity);
                       enemyCount++;
                       
                       
                       yield return new WaitForSeconds(timeBetweenEnemeies);
                   }

                   yield return new WaitForSeconds(timeBetweenWaves);
               }
           }
           
           else if (phaze == 2)
           {
               
               selectedWaves.Clear();
               int firstRandom = Random.Range(0, waveConfigs3.Count);
                
               
               selectedWaves.Add(waveConfigs3[firstRandom]);
               deletedWaves.Add(waveConfigs3[firstRandom]);
               waveConfigs.Remove(waveConfigs3[firstRandom]);
               int secondRandom = Random.Range(0, waveConfigs3.Count);
               selectedWaves.Add(waveConfigs3[secondRandom]);
               enemyCount += selectedWaves[0].getEnemyCount();
               enemyCount += selectedWaves[1].getEnemyCount();
               foreach (waveConfig wave in deletedWaves)
               {
                   waveConfigs.Add(wave);
               }
               deletedWaves.Clear();
               foreach (waveConfig wave in selectedWaves)
               {
                   
                   currentWave = wave;
                   for (int i = 0; i < currentWave.getEnemyCount(); i++)
                   {
                       GameObject enemy = Instantiate(currentWave.GetEnemyPrefab(i),
                           currentWave.getStartingPoint().position, Quaternion.identity);
                        
                       
                       yield return new WaitForSeconds(timeBetweenEnemeies);
                   }

                   

                   yield return new WaitForSeconds(timeBetweenWaves);
               }
           }
           
           else if (phaze == 3)
           {
               
               selectedWaves.Clear();
               int firstRandom = Random.Range(0, waveConfigs4.Count);
               selectedWaves.Add(waveConfigs4[0]);
               foreach (waveConfig wave in selectedWaves)
               {

                   currentWave = wave;
                   for (int i = 0; i < 1; i++)
                   {
                       GameObject enemy = Instantiate(currentWave.GetEnemyPrefab(i),
                           currentWave.getStartingPoint().position, Quaternion.identity);
                       enemyCount++;
                       
                       
                       yield return new WaitForSeconds(timeBetweenEnemeies);
                   }

                   yield return new WaitForSeconds(timeBetweenWaves);
               }
           }
           

       }
       
       
   
       public waveConfig GetCurrentWave()
       {
           return currentWave;
       }
       void Update()
       {
           
       }

       public void decreaseEnemyCountByOne()
       {
           --enemyCount;
           Debug.Log("enemy count is " + enemyCount);
           if (enemyCount <= 0)
           {
               
                   ++phaze;
               Debug.Log("PHAZZE "+phaze);
               
               if (phaze == 4) phaze = 0;
               StartCoroutine(spawn());
           }
       }
       
       
}
