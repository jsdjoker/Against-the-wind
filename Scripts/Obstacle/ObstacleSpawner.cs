using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstaclePrefabs;
    [SerializeField] float objectSpawnTime = 1f;
    [SerializeField] Transform obstalceparent;
    [SerializeField] float spawnWidth = 4f;

     void Start()
    {
        StartCoroutine(SpawnObstacleRoutine());
    }

    IEnumerator SpawnObstacleRoutine()
    {
        while (true)
        {
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnWidth, spawnWidth), transform.position.y, transform.position.z);
            yield return new WaitForSeconds(objectSpawnTime);
            Instantiate(obstaclePrefab, spawnPosition, Random.rotation,obstalceparent);
        }
    }
}
