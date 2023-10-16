using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 1.0f;  // Kecepatan pergerakan latar belakang
    public float loopingDistance = 10.0f;  // Jarak sebelum melooping
    private Vector2 startPosition;
    private Transform loopingTrigger;
    private float currentDistance = 0.0f;

    private void Start()
    {
        startPosition = transform.position;        
    }

    private void Update()
    {
        if (currentDistance < loopingDistance)
        {
            // Menggerakkan latar belakang ke kiri
            float moveDistance = Time.deltaTime * scrollSpeed;
            transform.position += Vector3.left * moveDistance;
            currentDistance += moveDistance;
        }
        else
        {
            // Latar belakang telah mencapai jarak looping
            ResetPosition();
        }
    }

    private void ResetPosition()
    {
        // Mengatur ulang posisi latar belakang ke awal
        transform.position = startPosition;
        currentDistance = 0.0f;
    }

}
