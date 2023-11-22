using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ScoreThreshold
{
    public float threshold;
    public float scrollSpeed;
}

public class GameScoreManager : MonoBehaviour
{
    public Text scoreText; // UI Text untuk menampilkan skor
    public float initialScrollSpeed = 1.0f;
    public List<ScoreThreshold> scoreThresholds;

    private float currentScrollSpeed;
    private float score = 0.0f;

    private void Start()
    {
        currentScrollSpeed = initialScrollSpeed;
        UpdateScoreText();
    }

    private void Update()
    {
        // Mengupdate skor
        score += Time.deltaTime;
        UpdateScoreText();

        // Mengupdate scrollSpeed berdasarkan skor
        UpdateGameParameters();

        // Menggerakkan latar belakang
        MoveBackground();
    }

    private void UpdateScoreText()
    {
        // Mengupdate teks skor pada UI
        if (scoreText != null)
        {
            scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
        }
    }

    private void UpdateGameParameters()
    {
        // Mengatur parameter permainan berdasarkan skor
        foreach (ScoreThreshold threshold in scoreThresholds)
        {
            if (score > threshold.threshold)
            {
                currentScrollSpeed = threshold.scrollSpeed;
            }
        }
    }

    private void MoveBackground()
    {
        // Menggerakkan latar belakang ke kiri berdasarkan scrollSpeed
        float moveDistance = Time.deltaTime * currentScrollSpeed;
        transform.position += Vector3.left * moveDistance;
    }
}
