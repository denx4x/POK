using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float initialScrollSpeed = 1.0f;
    private float currentScrollSpeed;    
    
    private void Start()
    {
        currentScrollSpeed = initialScrollSpeed;
    }


    void Update()
    {
        MoveBackground();
    }

    private void MoveBackground()
    {
        // Menggerakkan latar belakang ke kiri berdasarkan scrollSpeed
        float moveDistance = Time.deltaTime * currentScrollSpeed;
        transform.position += Vector3.left * moveDistance;
    }
}
