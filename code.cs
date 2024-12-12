using UnityEngine;
using UnityEngine.UIElements;

public class BlockSpawner : MonoBehaviour
{
    public UIDocument uiDocument;
    public GameObject blockPrefab;
    private Button generateButton;

    void Start()
    {
        VisualElement root = uiDocument.rootVisualElement;
        generateButton = root.Q<Button>("generateMaze");

        if (generateButton != null)
        {
            generateButton.clicked += () =>
            {
                SpawnRandom();
                generateButton.SetEnabled(false); // Disable button after spawning
            };
        }
        else
        {
            Debug.LogError("Button not found! Make sure the button has the correct name.");
        }
    }

    void SpawnBlock()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-14f, 14f), 0.5f, Random.Range(-20f, 20f));
        Instantiate(blockPrefab, spawnPosition, Quaternion.Euler(0, Random.Range(0f, 360f), 0));
    }

    void SpawnRandom()
    {
        int numberOfBlocks = Random.Range(3, 10); // Generate a random number of blocks between 3 and 9
        for (int i = 1; i <= numberOfBlocks; i++)
        {
            SpawnBlock();
        }
    }
}
