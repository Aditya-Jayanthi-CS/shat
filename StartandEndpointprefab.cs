using UnityEngine;

public class MazePoints : MonoBehaviour
{
    public GameObject startPrefab;  
    public GameObject endPrefab;   
    public Vector3 gridStartPosition = Vector3.zero;  

    public void AddStartAndEndPoints(int gridWidth, int gridHeight, int gridSpacing)
    {
     
        Vector3 startPosition = gridStartPosition;
        Vector3 endPosition = gridStartPosition + new Vector3((gridWidth - 1) * gridSpacing, 0f, (gridHeight - 1) * gridSpacing);

       
        if (startPrefab != null)
        {
            Instantiate(startPrefab, startPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Start prefab not assigned!");
        }

        
        if (endPrefab != null)
        {
            Instantiate(endPrefab, endPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("End prefab not assigned!");
        }
    }
}

public class GridSpawner : MonoBehaviour
{
    public GameObject cubiclePrefab;   
    public UIDocument uiDocument;      
    public MazePoints mazePoints;       

    private int[] rotationAngles = { 0, 90, 180, 270, 360 };  
    public Vector3 gridStartPosition = Vector3.zero;  

    void Start()
    {
      
        VisualElement root = uiDocument.rootVisualElement;
        Button generateButton = root.Q<Button>("generateMaze");

        if (generateButton != null)
        {
        
            generateButton.clicked += () => GenerateMaze(10, 10, 2);
        }
        else
        {
            Debug.LogError("Button not found! Make sure the button has the correct name.");
        }
    }

    void GenerateMaze(int gridWidth, int gridHeight, int gridSpacing)
    {
      
        for (int x = 0; x < gridWidth; x++)
        {
            for (int z = 0; z < gridHeight; z++)
            {
              
                Vector3 position = gridStartPosition + new Vector3(x * gridSpacing, 0f, z * gridSpacing);

         
                float randomRotation = rotationAngles[Random.Range(0, rotationAngles.Length)];

                Quaternion rotation = Quaternion.Euler(0f, randomRotation, 0f);

        
                Instantiate(cubiclePrefab, position, rotation);
            }
        }

        if (mazePoints != null)
        {
            mazePoints.AddStartAndEndPoints(gridWidth, gridHeight, gridSpacing);
        }
        else
        {
            Debug.LogError("MazePoints script not assigned!");
        }
    }
}
