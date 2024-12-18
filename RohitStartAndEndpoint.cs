using UnityEngine;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    public GameObject startPrefab;
    public GameObject endPrefab;
    public GameObject player;

    // Student-developed procedure
    void SpawnPoints(List<Vector3> positions, bool spawnStartPoints)
    {
        foreach (Vector3 position in positions)
        {
            // Selection: Decide which prefab to spawn based on the parameter
            GameObject prefabToSpawn = spawnStartPoints ? startPrefab : endPrefab;

            // Instantiate the prefab at the given position
            GameObject spawnObject = Instantiate(prefabToSpawn, position, Quaternion.identity);

            // If spawning start points, set the player position to the last start point
            if (spawnStartPoints)
            {
                player.transform.position = spawnObject.transform.position;
            }

            // Log the spawned position
            Debug.Log((spawnStartPoints ? "Start" : "End") + " prefab instantiated at: " + position);
        }
    }

    void Start()
    {
        // Sequence: Define positions to spawn and store them in a List
        List<Vector3> positions = new List<Vector3>()
        {
            new Vector3(0, 0, 0),
            new Vector3(10, 0, 0),
            new Vector3(20, 0, 0),
            new Vector3(30, 0, 0),
            new Vector3(40, 0, 0)
        };

        // Call the student-developed procedure with parameters
        SpawnPoints(positions, true);  // Spawn start points
        SpawnPoints(positions, false); // Spawn end points

        // Create new data from the existing data
        List<Vector3> newPositions = new List<Vector3>();
        foreach (Vector3 position in positions)
        {
            // Create new positions by offsetting the existing ones
            Vector3 newPosition = position + new Vector3(5, 0, 5);
            newPositions.Add(newPosition);
        }

        // Use the new data to spawn additional points
        SpawnPoints(newPositions, true);  // Spawn start points at new positions
        SpawnPoints(newPositions, false); // Spawn end points at new positions
    }
}

