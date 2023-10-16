using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        // Mendapatkan input horizontal (kanan dan kiri)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Mendapatkan input vertical (atas dan bawah)
        float verticalInput = Input.GetAxis("Vertical");

        // Menghitung vektor pergerakan
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        // Menggerakkan pemain
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
