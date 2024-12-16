using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    public GameObject cubiclePrefab;
    public GameObject startPrefab;
    public GameObject endPrefab;
    public Vector3 gridStartPosition = Vector3.zero;

    void Start()
    {
        GenerateMaze(10, 10, 2);
    }

    void GenerateMaze(int gridWidth, int gridHeight, int gridSpacing)
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int z = 0; z < gridHeight; z++)
            {
                Vector3 position = gridStartPosition + new Vector3(x * gridSpacing, 0f, z * gridSpacing);
                Quaternion rotation = Quaternion.Euler(0f, Random.Range(0, 360), 0f);
                Instantiate(cubiclePrefab, position, rotation);
            }
        }

        Vector3 startPosition = gridStartPosition;
        Vector3 endPosition = gridStartPosition + new Vector3((gridWidth - 1) * gridSpacing, 0f, (gridHeight - 1) * gridSpacing);
        
        SpawnStartPoint(startPosition);
        SpawnEndPoint(endPosition);
    }

    void SpawnStartPoint(Vector3 position)
    {
        if (startPrefab != null)
        {
            Instantiate(startPrefab, position, Quaternion.identity);
            Debug.Log("Start prefab instantiated at: " + position);
        }
    }

    void SpawnEndPoint(Vector3 position)
    {
        if (endPrefab != null)
        {
            Instantiate(endPrefab, position, Quaternion.identity);
            Debug.Log("End prefab instantiated at: " + position);
        }
    }
}
