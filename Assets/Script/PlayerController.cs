using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float damping = 0.5f; // Nilai damping untuk memberikan efek berhenti cepat

    public int gameOverSceneIndex; // Indeks scene untuk game over

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Mendapatkan input horizontal (kanan dan kiri)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Mendapatkan input vertical (atas dan bawah)
        float verticalInput = Input.GetAxis("Vertical");

        // Menghitung vektor pergerakan
        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

        // Menggunakan linear interpolation untuk membuat pergerakan lebih smooth
        Vector2 targetVelocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        rb.velocity = Vector2.Lerp(rb.velocity, targetVelocity, damping);

        // Menghentikan pergerakan jika tidak ada input
        if (moveDirection == Vector2.zero)
        {
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, damping);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Cek apakah objek yang disentuh memiliki tag "Obstacle" (Anda dapat menyesuaikan tag sesuai dengan kebutuhan)
        if (other.CompareTag("Obstacle"))
        {
            // Memanggil fungsi GameOver dengan indeks scene yang ditentukan
            GameOver();
        }
    }

    public void GameOver()
    {
        // Menambahkan log untuk memastikan fungsi GameOver dipanggil
        Debug.Log("Game Over!");

        // Merestart scene berdasarkan indeks yang ditentukan
        SceneManager.LoadScene(gameOverSceneIndex);
    }
}
