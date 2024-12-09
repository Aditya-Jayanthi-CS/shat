using UnityEngine;
using UnityEngine.UIElements;  // Make sure to include this for UIElements components

public class GridSpawner : MonoBehaviour
{
    public GameObject cubiclePrefab;  // The prefab to instantiate
    public Vector3 gridStartPosition = Vector3.zero;  // Starting position of the grid (adjustable)
    public UIDocument uiDocument;     // Reference to the UI Document

    private int[] rotationAngles = { 0, 90, 180, 270, 360 };  // Array of possible rotation angles

    void Start()
    {
        // Find the button in the UI Document and assign the GenerateMaze method to its click event
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
}
