using UnityEngine;
using UnityEngine.UIElements;
using System.Drawing;

public class MazeRandomizer : MonoBehaviour
{
    public GameObject blockPrefab;
    private Button generateButton;
    public GameObject cubiclePrefab;  // The cubicle prefab
    public Vector3 gridStartPosition = Vector3.zero;  // Starting coords of the grid
    public UIDocument uiDocument;     //UI stuff
    public GameObject startPrefab;
    public GameObject endPrefab;
    public GameObject player;
    private int[] rotationAngles = { 0, 90, 180, 270, 360 };  //list of random rotations for prefab

    public GameObject Prefab1;
    public GameObject Prefab2;
    public GameObject Prefab3;
    public List<GameObject> prefabs = new List<GameObject>();

    void Start()
    {
        prefabs.Add(Prefab1);
        prefabs.Add(Prefab2);
        prefabs.Add(Prefab3);
        
        VisualElement root = uiDocument.rootVisualElement;
        generateButton = root.Q<Button>("generateMaze");

        if (generateButton != null)
        {
            generateButton.clicked += () =>
            {
                RandomizeMaze();
                generateButton.SetEnabled(false); // Disable button after spawning
            };
        }
    }

    void SpawnBlockMaze()
    {
        //Aditya's maze function
        int randomIndex = Random.Range(0, prefabs.Count);
        int numberOfBlocks = Random.Range(50, 75);
        for (int i = 1; i <= numberOfBlocks; i++)
        {
            Vector3 anotherRandomPosition = new Vector3(Random.Range(-10f, 10f), 0.5f, Random.Range(-10f, 10f));
            Instantiate(prefabs[randomIndex], anotherRandomPosition, Quaternion.identity);
        }
    }

    void GenerateGridMaze(int gridWidth, int gridHeight, int gridSpacing)
    {
        //Arnav's maze function

        // Loop through the grid dimensions and instantiate the prefab at the correct positions
        for (int x = 0; x < gridWidth; x++)
        {
            for (int z = 0; z < gridHeight; z++)
            {
                // Calculate the position for each cubicle, offset by the starting position
                Vector3 position = gridStartPosition + new Vector3(x * gridSpacing, 0f, z * gridSpacing);

                // Choose a random rotation angle from the array
                float randomRotation = rotationAngles[Random.Range(0, rotationAngles.Length)];

                // Create a rotation quaternion with the random rotation angle around the Y axis
                Quaternion rotation = Quaternion.Euler(0f, randomRotation, 0f);

                // Instantiate the cubicle at the calculated position with the random rotation
                Instantiate(cubiclePrefab, position, rotation);
            }
        }
    }

    void RandomizeMaze()
    {
        //Vijayesh's randomise function
        int mazeType = Random.Range(0, 2); // Randomly choose 0 or 1

        if (mazeType == 0)
        {
            SpawnBlockMaze();
        }
        else
        {
            GenerateGridMaze(10, 10, 2); // Adjust parameters as needed
        }
    }
    void GenerateColor(int minRed, int maxRed, int minGreen, int maxGreen, int minBlue, int maxBlue)
    {
        //Prabhav's color function
        System.Random random = new System.Random();

        for (int i = 0; i < 5; i++)
        {
            int red = random.Next(minRed, maxRed + 1);
            int green = random.Next(minGreen, maxGreen + 1);
            int blue = random.Next(minBlue, maxBlue + 1);

            UnityEngine.Color randomColor = new UnityEngine.Color(red / 255f, green / 255f, blue / 255f);
            Debug.Log($"Random color for maze walls: {randomColor}");

            if (GetComponent<Renderer>() != null)
            {
                GetComponent<Renderer>().material.color = randomColor;
            }
        }
    }

    void SpawnStartPoint(Vector3 position)
    {
        //Rohit's spawn randomiser function
        Vector3 spawnpos1 = new Vector3(Random.Range(-9.5f, 9.5f), 0.5f, Random.Range(-9.5f, 9.5f));
        GameObject spawnObject = Instantiate(startPrefab, spawnpos1, Quaternion.identity);
        player.transform.position=spawnObject.transform.position
        Debug.Log("Start prefab instantiated at: " + position);
    }

    void SpawnEndPoint(Vector3 position)
    {
        //Rohit's spawn randomiser function
        Vector3 spawnpos2 = new Vector3(Random.Range(-9.5f, 9.5f), 0.5f, Random.Range(-9.5f, 9.5f));
        Instantiate(endPrefab, spawnpos2, Quaternion.identity);
        Debug.Log("End prefab instantiated at: " + position);
    }


}
