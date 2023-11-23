using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // Array prefab objek
    public float spawnInterval = 2f;     // Interval waktu antara spawn
    public int numberOfObjects = 10;     // Jumlah objek yang akan di-spawn

    [Header("Spawn Position Range")]
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -5f;
    public float maxY = 5f;

    void Start()
    {
        StartCoroutine(SpawnObjectsWithInterval());
    }

    private void SpawnObject()
    {
        // Memilih prefab objek secara acak
        GameObject randomObjectPrefab = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];

        // Menghasilkan posisi acak dalam rentang yang ditentukan
        Vector2 randomSpawnPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        // Membuat instance objek dan mengatur posisi
        GameObject spawnedObject = Instantiate(randomObjectPrefab, randomSpawnPosition, Quaternion.identity);

        // Add a Rigidbody2D component to the spawned object
        Rigidbody2D rb2d = spawnedObject.AddComponent<Rigidbody2D>();
        rb2d.gravityScale = 0; // Set gravity scale to 0 to let the object float

        // Add the MoveLeft script to the spawned object
        MoveLeft moveLeftScript = spawnedObject.AddComponent<MoveLeft>();
    }

    private IEnumerator SpawnObjectsWithInterval()
    {
        while (numberOfObjects > 0)
        {
            SpawnObject(); // Panggil metode SpawnObject

            // Tunggu sebelum memanggil kembali SpawnObject
            yield return new WaitForSeconds(spawnInterval);

            // Kurangi jumlah objek yang harus di-spawn
            numberOfObjects--;
        }
    }
}
