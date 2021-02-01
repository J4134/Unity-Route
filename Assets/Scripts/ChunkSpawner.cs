using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject chunkPrefab;

    [SerializeField]
    private int initialChunksCount;

    private List<GameObject> spawnedChunks = new List<GameObject>();

    private void Awake()
    {
        GetSpawnedChunks();
        SpawnNewChunk(initialChunksCount);
    }

    private void GetSpawnedChunks()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            spawnedChunks.Add(transform.GetChild(i).gameObject);
        }
    }

    private Vector3 GetNewChunkPos()
    {
        var lastChunkPos = spawnedChunks[spawnedChunks.Count - 1].transform.position;

        if (Random.Range(0, 2) == 0)
        {
            return new Vector3(lastChunkPos.x, lastChunkPos.y, lastChunkPos.z + chunkPrefab.transform.localScale.z);
        }
        else
        {
            return new Vector3(lastChunkPos.x + chunkPrefab.transform.localScale.x, lastChunkPos.y, lastChunkPos.z);
        }
    }

    public void SpawnNewChunk()
    {
        var newChunk = Instantiate(chunkPrefab, GetNewChunkPos(), Quaternion.identity, transform);
        Destroy(spawnedChunks[0]);
        spawnedChunks.Remove(spawnedChunks[0]);
        spawnedChunks.Add(newChunk);
    }

    public void SpawnNewChunk(int newChunksCount)
    {
        for (int i = 0; i < newChunksCount; i++)
        {
            var newChunk = Instantiate(chunkPrefab, GetNewChunkPos(), Quaternion.identity, transform);
            spawnedChunks.Add(newChunk);
        }
    }
}
