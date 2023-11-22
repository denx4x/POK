using UnityEngine;
using System.Collections;

public class BlinkingPlayButton : MonoBehaviour
{
    // Waktu berkedip dalam detik
    public float blinkInterval = 0.5f;

    // Daftar warna yang akan digunakan saat berkedip
    public Color[] blinkColors;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        // Dapatkan komponen SpriteRenderer dari objek
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Pastikan setidaknya ada satu warna dalam daftar
        if (blinkColors.Length == 0)
        {
            Debug.LogError("No blink colors defined!");
            return;
        }

        // Mulai coroutines untuk berkedip pada saat awal
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        int colorIndex = 0;

        while (true)
        {
            // Ganti warna sesuai dengan indeks
            spriteRenderer.color = blinkColors[colorIndex];

            // Tunggu sebentar
            yield return new WaitForSeconds(blinkInterval);

            // Ganti indeks warna untuk berpindah ke warna berikutnya
            colorIndex = (colorIndex + 1) % blinkColors.Length;
        }
    }
}
