using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -5f;
    public float maxY = 5f;
    public int numberOfObjects = 10;

    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            SpawnObject();
            yield return null;
        }
    }

    void SpawnObject()
    {
        GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);

        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

        // Tambahkan komponen Rigidbody2D
        Rigidbody2D rb2d = spawnedObject.AddComponent<Rigidbody2D>();
        rb2d.gravityScale = 0; // Biarkan objek mengambang

        // Tambahkan skrip MoveLeft
        MoveLeft moveLeftScript = spawnedObject.AddComponent<MoveLeft>();
        moveLeftScript.speed = 5f; // Atur kecepatan objek yang bergerak ke kiri
    }
}
