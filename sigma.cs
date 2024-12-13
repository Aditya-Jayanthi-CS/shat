using UnityEngine;
using UnityEngine.UIElements;
using System;

  public class RandomColor : MonoBehaviour
  {   
      public static void GenerateColor(int minRed, int maxRed, int minGreen, int maxGreen, int minBlue, int maxBlue) 
      { 
          System.Random random = new System.Random();

          for (int i = 0; i < count; i + +)
          {
              int red = random.Next(minRed, maxRed + 1); 
              int green = random.Next(minGreen, maxGreen + 1); 
              int blue = random.Next(minBlue, maxBlue + 1); 
  
              Color randomColor = Color.FromArgb(red, green, blue); 
              Console.WriteLine($"Random color for maze walls: #{randomColor.R:X2}{randomColor.G:X2}{randomColor.B:X2}");

              if (renderer != null) 
              {
                  renderer.material.color = randomColor;
          }

      public static void Main()
      {
          GeneratorColor(50, 200, 100, 255, 0, 150);
      }
}

public class GridSpawner : MonoBehaviour
{
    public GameObject cubiclePrefab;
    public Vector3 gridStartPosition = Vector3.zero;
    public UIDocument uiDocument;

    private int[] rotationAngles = { 0, 90, 180, 270 };  // List of possible rotations for the cubicle

    void Start()
    {
        // Find the button in the UIDocument
        VisualElement root = uiDocument.rootVisualElement;
        Button generateButton = root.Q<Button>("generateMaze");

        // As long as there is a button, generate the maze
        if (generateButton != null)
        {
            generateButton.clicked += () => GenerateMaze(9, 9, 2);
        }
    }

    void GenerateMaze(int gridWidth, int gridHeight, int gridSpacing)
    {
        // Loop through the grid
        for (int x = 0; x < gridWidth; x++)
        {
            for (int z = 0; z < gridHeight; z++)
            {
                // Ensure gridSpacing is valid
                if (gridSpacing < 0)
                {
                    gridSpacing = 2;
                }

                // Calculate the position for each cubicle
                Vector3 position = gridStartPosition + new Vector3(x * gridSpacing, 0f, z * gridSpacing);

                // Choose a random rotation
                float randomRotation = rotationAngles[Random.Range(0, rotationAngles.Length)];

                // Create a rotation with random value
                Quaternion rotation = Quaternion.Euler(0f, randomRotation, 0f);

                // Instantiate the cubicle
                Instantiate(cubiclePrefab, position, rotation);
            }
        }
    }
}
