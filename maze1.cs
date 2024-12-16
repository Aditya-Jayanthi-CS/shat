using UnityEngine;
using UnityEngine.UIElements; 

public class GridSpawner : MonoBehaviour
{
    public GameObject cubiclePrefab;  // The cubicle prefab
    public Vector3 gridStartPosition = Vector3.zero;  // Starting coords of the grid
    public UIDocument uiDocument;     //UI stuff

    private int[] rotationAngles = { 0, 90, 180, 270, 360 };  //list of random rotations for prefab

    void Start()
    {
        // Find the button and check if clicked
        VisualElement root = uiDocument.rootVisualElement;
        Button generateButton = root.Q<Button>("generateMaze");

        if (generateButton != null)
        {
            generateButton.clicked += () => GenerateMaze(10, 10, 2);
        }
    }

    void GenerateMaze(int gridWidth, int gridHeight, int gridSpacing)
    {
        // Loop through the grid dimensions provided and instantiante
        for (int x = 0; x < gridWidth; x++)
        {
            for (int z = 0; z < gridHeight; z++)
            {
                //find the position and rotation for the prefab
                Vector3 position = gridStartPosition + new Vector3(x * gridSpacing, 0f, z * gridSpacing);
                float randomRotation = rotationAngles[Random.Range(0, rotationAngles.Length)];

                // choose a rotation
                Quaternion rotation = Quaternion.Euler(0f, randomRotation, 0f);

                // Instantiate the cubicle
                Instantiate(cubiclePrefab, position, rotation);
            }
        }
    }
}
