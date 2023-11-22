using UnityEngine;

public class DespawnBackground : MonoBehaviour
{
    [SerializeField] private float despawnTime = 500f;

    private void Start()
    {
        Invoke("Despawn", despawnTime);
    }

    private void Despawn()
    {
        Destroy(gameObject);
    }
}
