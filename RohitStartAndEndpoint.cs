using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    public GameObject startPrefab;
    public GameObject endPrefab;
    public GameObject player;

    private List<Vector3> spawnPositions = new List<Vector3>();

    void Start()
    {
       
        SpawnPoints();
    }

    void SpawnPoints()
    {
        int spawnCount = 0;
        while (spawnCount < 2)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-9.5f, 9.5f), 0.5f, Random.Range(-9.5f, 9.5f));
            
         
            if (!spawnPositions.Contains(spawnPosition)) 
            {
                spawnPositions.Add(spawnPosition);

              
                for (int i = 0; i < 1; i++)
                {
                    if (spawnCount == 0)
                    {
                        SpawnStartPoint(spawnPosition);
                    }
                    else
                    {
                        SpawnEndPoint(spawnPosition);
                    }
                }

                spawnCount++;
            }
        }
    }

    void SpawnStartPoint(Vector3 position)
    {
        //Rohit's spawn randomiser function
        GameObject spawnObject = Instantiate(startPrefab, position, Quaternion.identity);
        player.transform.position = spawnObject.transform.position;
        Debug.Log("Start prefab instantiated at: " + position);
    }

    void SpawnEndPoint(Vector3 position)
    {
        //Rohit's spawn randomiser function
        Instantiate(endPrefab, position, Quaternion.identity);
        Debug.Log("End prefab instantiated at: " + position);
    }
}

