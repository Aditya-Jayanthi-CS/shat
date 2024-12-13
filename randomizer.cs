using UnityEngine;
using UnityEngine.UIElements;

public class MazeRandomizer : MonoBehaviour
{
    public UIDocument uiDocument;
    public GameObject blockPrefab;
    public GameObject cubiclePrefab;
    private Button generateButton;

    void Start()
    {
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
        else
        {
            Debug.LogError("Button not found! Make sure the button has the correct name.");
        }
    }

    void SpawnBlockMaze()
    {
        int numberOfBlocks = Random.Range(3, 10); // Generate a random number of blocks between 3 and 9
        for (int i = 1; i <= numberOfBlocks; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-14f, 14f), 0.5f, Random.Range(-20f, 20f));
            Instantiate(blockPrefab, spawnPosition, Quaternion.Euler(0, Random.Range(0f, 360f), 0));
        }
    }

    void GenerateGridMaze(int gridWidth, int gridHeight, int gridSpacing)
    {
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
}
