using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("AudioManager").AddComponent<AudioManager>();
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

    public AudioSource audioSource;
    public int sceneIndexToStopAudio = 1; // Index scene di mana audio harus dihentikan

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayAudio(AudioClip clip)
    {
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = clip;
        audioSource.Play();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Memeriksa apakah scene saat ini adalah scene dengan index yang ditentukan untuk menghentikan audio
        if (scene.buildIndex == sceneIndexToStopAudio)
        {
            // Menghentikan audio
            if (audioSource != null)
            {
                audioSource.Stop();
            }
        }
        else
        {
            // Jika scene bukan scene untuk menghentikan audio, Anda bisa menetapkan audio yang sesuai di sini
            // (misalnya, melanjutkan audio atau memutar audio yang sesuai untuk scene baru)
        }
    }
}
