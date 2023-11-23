using UnityEngine;

public class ClickToShowObject : MonoBehaviour
{
    public GameObject objectToShow;

    private void OnMouseDown()
    {
        if (objectToShow != null)
        {
            // Toggle keadaan aktif/non-aktif game object yang ingin ditampilkan/sembunyikan
            objectToShow.SetActive(!objectToShow.activeSelf);
        }
    }
}
