using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    // Public variable for the obstacle prefab
    public GameObject obstaclePrefab;

    // Starting Y position
    private float startY = -1.72f;

    // Increment for Y position
    private float incrementY = 1.34f;

    // Public variable for spawn interval
    public float spawnInterval = 1f;

    void Start()
    {
        // Start spawning obstacles
        Spawn();
    }

    void Spawn()
    {
        // Determine a random X position of 12 or -12
        float randomX = Random.Range(0, 2) == 0 ? 12f : -12f;

        // Instantiate the obstacle prefab at the determined position
        Vector3 spawnPosition = new Vector3(randomX, startY, 0f);
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

        // Increase the Y position for the next spawn
        startY += incrementY;

        // Repeat the spawn method with specified interval
        Invoke("Spawn", spawnInterval);
    }

    // Method to stop spawning obstacles
    public void StopSpawning()
    {
        CancelInvoke("Spawn");
    }
}
