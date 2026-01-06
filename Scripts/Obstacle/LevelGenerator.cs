using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] CameraController cameraController;
   [SerializeField] GameObject ChunkPrefarb;
   [SerializeField] int startingChunkAmount = 12;
   [SerializeField] Transform chunkParent;
   [SerializeField] float chunkLength = 10f;
   [SerializeField] float moveSpeed = 8f;
   [SerializeField] float minMoveSpeed = 2f;
   


    List<GameObject> chunks = new List<GameObject>();

    void Start()
    {
        SpawnStartingChunk();
    }

    private void Update()
    {
        MoveChunks();
    }

    public void ChangeChunkMoveSpeed(float speedAmount)
    {
        moveSpeed += speedAmount;

        if(moveSpeed < minMoveSpeed)
        {
            moveSpeed = minMoveSpeed;   
        }

        Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, Physics.gravity.z - speedAmount);

        cameraController.ChangeCameraFov(speedAmount);
    }

    private void SpawnStartingChunk()
    {
        for (int i = 0; i < startingChunkAmount; i++)
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
        float spawnpostiionZ = calcuateSpawnPostion();
        Vector3 chunckSpawnPos = new Vector3(transform.position.x, transform.position.y, spawnpostiionZ);
        GameObject newChunk = Instantiate(ChunkPrefarb, chunckSpawnPos, Quaternion.identity, chunkParent);

        chunks.Add(newChunk);
    }

    private float calcuateSpawnPostion()
    {
        float spawnpostiionZ;


        if (chunks.Count == 0)
        {
            spawnpostiionZ = transform.position.z;
        }
        else
        {
            spawnpostiionZ = chunks[chunks.Count - 1].transform.position.z + chunkLength;

        }

        return spawnpostiionZ;
    }

    void MoveChunks()
    {
        for (int i = 0; i < chunks.Count; i++)
        {
            GameObject chunk = chunks[i];
            chunks[i].transform.Translate(-transform.forward *( moveSpeed * Time.deltaTime));

            if(chunk.transform.position.z <= Camera.main.transform.position.z - chunkLength)
            {
                chunks.Remove(chunk);
                Destroy(chunk);
                SpawnChunk();
            }
        }
    }
}
