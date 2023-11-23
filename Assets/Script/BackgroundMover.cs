using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    public Transform targetPosition;
    public float moveSpeed = 5f;
    private float currentScrollSpeed;
    public float initialScrollSpeed = 1.0f;

    private void Start()
    {
        currentScrollSpeed = initialScrollSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Detect"))
        {
            // Langsung berpindah ke targetPosition
            MoveToTargetPosition();
        }
    }

    private void Update()
    {
        MoveBackground();
    }

    private void MoveToTargetPosition()
    {
        if (targetPosition != null)
        {
            // Langsung atur posisi objek ke targetPosition
            transform.position = new Vector3(targetPosition.position.x, targetPosition.position.y, targetPosition.position.z);
        }
        else
        {
            Debug.LogWarning("Target position is not set. Cannot move to target position.");
        }
    }

    private void MoveBackground()
    {
        float moveDistance = Time.deltaTime * currentScrollSpeed;
        transform.position += Vector3.left * moveDistance;
    }
}
