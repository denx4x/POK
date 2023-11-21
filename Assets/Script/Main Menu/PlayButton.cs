using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    // Animasi efek klik
    public float clickScale = 0.9f;
    public float clickDuration = 0.1f;

    // Indeks scene yang dituju
    public int targetSceneIndex;

    private void OnMouseDown()
    {
        // Efek klik
        StartCoroutine(ClickAnimation());

        // Pindah ke scene baru setelah efek klik selesai
        Invoke("LoadTargetScene", clickDuration);
    }

    IEnumerator ClickAnimation()
    {
        // Simpan skala awal
        Vector3 originalScale = transform.localScale;

        // Ubah skala tombol
        transform.localScale = originalScale * clickScale;

        // Tunggu sebentar
        yield return new WaitForSeconds(clickDuration);

        // Kembalikan skala awal
        transform.localScale = originalScale;
    }

    void LoadTargetScene()
    {
        // Pastikan indeks scene valid
        if (targetSceneIndex >= 0 && targetSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            // Pindah ke scene yang dituju
            SceneManager.LoadScene(targetSceneIndex);
        }
        else
        {
            Debug.LogWarning("Invalid target scene index!");
        }
    }
}
