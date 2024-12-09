using UnityEngine;
using UnityEngine.UIElements;

public class BlockSpawner : MonoBehaviour
{
    public UIDocument uiDocument;
    public GameObject blockPrefab;

    void Start()
    {
        // Find the button in the UI Document and assign the GenerateMaze method to its click event
        VisualElement root = uiDocument.rootVisualElement;
        Button generateButton = root.Q<Button>("generateMaze");

        if (generateButton != null)
        {
            generateButton.clicked += () => SpawnRandom(5);
        }
        else
        {
            Debug.LogError("Button not found! Make sure the button has the correct name.");
        }
    }

    void SpawnBlock()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-14f, 14f), 0.5f, Random.Range(-13.5f, 13.5f));
        Instantiate(blockPrefab, spawnPosition, Quaternion.Euler(0, Random.Range(0f, 360f), 0));
    }

    void SpawnRandom(int numberOfBlocks)
    {
        for (int i = 1; i <= numberOfBlocks; i++)
        {
            SpawnBlock();
        }
    }
}
