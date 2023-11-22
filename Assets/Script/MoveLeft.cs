using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // Kecepatan yang dapat diatur dari Inspector
    public float speed = 5f;

    void Update()
    {
        // Pindahkan objek ke kiri
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Hapus objek jika melewati batas kiri tertentu
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}
