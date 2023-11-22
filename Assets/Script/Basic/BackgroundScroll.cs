using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 1.0f;  // Kecepatan pergerakan latar belakang
    public float deleteDistance = 10.0f;  // Jarak sebelum objek dihapus
    private Vector2 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        // Menggerakkan latar belakang ke kiri
        float moveDistance = Time.deltaTime * scrollSpeed;
        transform.position += Vector3.left * moveDistance;

        // Mengecek apakah objek harus dihapus
        if (transform.position.x < (startPosition.x - deleteDistance))
        {
            // Objek telah mencapai jarak untuk dihapus
            Destroy(gameObject);
        }
    }

}
