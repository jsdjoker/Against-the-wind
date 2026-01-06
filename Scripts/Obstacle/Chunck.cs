using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Chunck : MonoBehaviour
{
    [SerializeField] GameObject fencepefrab;
    [SerializeField] GameObject Applepefrab;
    [SerializeField] GameObject Coinpefrab;
    [SerializeField] float[] Lanes = { -2.5f, 0f, 2.5f };

    [SerializeField] float appleSpawnChanges = .3f;
    [SerializeField] float coinSpawnChanges = .5f;
    [SerializeField] float coinSeperationLength = 2f;

    List<int> availablelanes = new List<int> { 0, 1, 2 };
     void Start()
    {
        spawnFence();
        spawnApple();
        spawnCoins();
    }

    void spawnFence()
    {
        int fenceTospawn = Random.Range(0, Lanes.Length);

        for (int i = 0; i < fenceTospawn; i++)
        {
            if (availablelanes.Count <= 0) break;

            int selectedlanes = SelectLine();
            Vector3 spawnPosition = new Vector3(Lanes[selectedlanes], transform.position.y, transform.position.z);
            Instantiate(fencepefrab, spawnPosition, Quaternion.identity, this.transform);
        }

    }

    void spawnApple()
    {
        if (Random.value < appleSpawnChanges || availablelanes.Count <= 0) return;

        int selectedlanes = SelectLine();
        Vector3 spawnPosition = new Vector3(Lanes[selectedlanes], transform.position.y, transform.position.z);
        Instantiate(Applepefrab, spawnPosition, Quaternion.identity, this.transform);
    }

    void spawnCoins()
    {
        if (Random.value < coinSpawnChanges || availablelanes.Count <= 0) return;

        int maxCoinTospawn = 6;
        int coinToSpawn = Random.Range(1, maxCoinTospawn);

        int selectedlanes = SelectLine();

        float topChunkZpos = transform.position.z + (coinSeperationLength * 2f);

        for (int i = 0; i < coinToSpawn; i++)
        {
           float spawnPsotionZ = topChunkZpos - (i * coinSeperationLength);
           Vector3 spawnPosition = new Vector3(Lanes[selectedlanes], transform.position.y, transform.position.z);
           Instantiate(Coinpefrab, spawnPosition, Quaternion.identity, this.transform);
            
        }

        
    }

    private int SelectLine()
    {
        int RandomLaneindex = Random.Range(0, availablelanes.Count);
        int selectedlanes = availablelanes[RandomLaneindex];
        availablelanes.RemoveAt(RandomLaneindex);
        return selectedlanes;
    }

   
}
