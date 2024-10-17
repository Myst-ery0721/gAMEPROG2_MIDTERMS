using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyPrefabs; 
    private float minSpawnInterval = 5.0f; 
    private float maxSpawnInterval = 10.0f;

    private void Start()
    {

        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true) 
        {

            if (enemyPrefabs.Length == 0)
            {
                yield break; 
            }
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];


            Instantiate(enemyPrefab, transform.position, Quaternion.identity);


            float randomSpawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);

  
            yield return new WaitForSeconds(randomSpawnInterval);
        }
    }
}
