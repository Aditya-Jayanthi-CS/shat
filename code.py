using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab; // Reference to the block prefab
    public float spawnInterval = 2.0f; // Time interval between spawn

    void Start()
    {
        // Start the spawning process
        InvokeRepeating("SpawnBlock", 2f, 0f);
    }

    void SpawnBlock()
    {
        // Instantiate a new block at a specific position
        Vector3 spawnPosition = new Vector3(Random.Range(-14f,14f),0.5f, Random.Range(-13.5f,13.5f));// You can change the position as needed
        //transform.rotation.z = Random.Range(0, 360);
        xrotate = new Float(Random.Range(0f, 360f));
        zrotate = new Float(Random.Range(0f, 360f));
        Instantiate(blockPrefab, spawnPosition, Quaternion.Euler(xrotate,30,zrotate));
    }
}

//computer 16
