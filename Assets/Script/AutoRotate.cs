using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    public float rotationSpeed = 10f;

    void Update()
    {
        // Rotasi objek secara otomatis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
