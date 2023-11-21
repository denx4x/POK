using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    public GameObject[] backgroundPrefabs; // Array prefab latar belakang
    public Transform spawnPosition;        // Posisi spawn yang dapat disesuaikan
    public Transform customParent;         // Posisi parent yang dapat disesuaikan

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Periksa apakah objek yang men-trigger memiliki tag "Detect"
        if (other.CompareTag("Detect"))
        {
            SpawnBackground();
        }
    }

    private void SpawnBackground()
    {
        // Pastikan spawnPosition tidak null
        if (spawnPosition != null)
        {
            // Memilih prefab latar belakang secara acak
            GameObject randomBackgroundPrefab = backgroundPrefabs[Random.Range(0, backgroundPrefabs.Length)];

            // Membuat instance latar belakang dan mengatur posisi serta menjadikannya anak dari spawner atau parent yang di-kustom
            GameObject spawnedBackground = Instantiate(randomBackgroundPrefab, spawnPosition.position, Quaternion.identity);

            // Menjadikan customParent sebagai parent jika telah ditentukan
            if (customParent != null)
            {
                spawnedBackground.transform.parent = customParent;
            }
            else
            {
                // Menjadikan spawner sebagai parent jika customParent tidak ditentukan
                spawnedBackground.transform.parent = transform;
            }

            // Menambahkan script DespawnBackground pada latar belakang yang baru di-spawn
            spawnedBackground.AddComponent<DespawnBackground>();
        }
        else
        {
            Debug.LogWarning("spawnPosition kosong. Tidak dapat membuat latar belakang.");
        }
    }
}
