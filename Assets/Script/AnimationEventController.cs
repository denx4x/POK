using UnityEngine;

public class AnimationEventController : MonoBehaviour
{
    public GameObject objectToActivate;

    // Dipanggil dari animasi sebagai event saat animasi selesai atau pada titik tertentu
    public void ActivateGameObject()
    {
        objectToActivate.SetActive(true);
    }
}
