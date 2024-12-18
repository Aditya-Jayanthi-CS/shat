using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject startPrefab;
    public GameObject endPrefab;
    public GameObject player;

    void Start()
    {
        // Sequence: Define start and end positions
        Vector3 startPosition = new Vector3(0, 0, 0);
        Vector3 endPosition = new Vector3(10, 0, 0);

        // Selection: Determine which point to spawn
        if (Random.value > 0.5f)
        {
            SpawnStartPoint(startPosition);
        }
        else
        {
            SpawnEndPoint(endPosition);
        }

        // Iteration: Spawn multiple points
        for (int i = 0; i < 5; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            SpawnRandomPoint(randomPosition);
        }
    }

    void SpawnStartPoint(Vector3 position)
    {
        // Rohit's spawn randomiser function
        GameObject spawnObject = Instantiate(startPrefab, position, Quaternion.identity);
        player.transform.position = spawnObject.transform.position;
        Debug.Log("Start prefab instantiated at: " + position);
    }

    void SpawnEndPoint(Vector3 position)
    {
        // Rohit's spawn randomiser function
        Instantiate(endPrefab, position, Quaternion.identity);
        Debug.Log("End prefab instantiated at: " + position);
    }

    void SpawnRandomPoint(Vector3 position)
    {
        // Randomly select between startPrefab and endPrefab
        GameObject prefabToSpawn = (Random.value > 0.5f) ? startPrefab : endPrefab;
        Instantiate(prefabToSpawn, position, Quaternion.identity);
        Debug.Log("Random prefab instantiated at: " + position);
    }
}

