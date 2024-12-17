int randomIndex = Random.Range(0, prefabs.Count);
Vector3 anotherRandomPosition = new Vector3(Random.Range(-10f, 10f), 0.5f, Random.Range(-10f, 10f));
Instantiate(prefabs[randomIndex], anotherRandomPosition, Quaternion.identity);
