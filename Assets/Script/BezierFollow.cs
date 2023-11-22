using UnityEngine;

public class BezierFollow : MonoBehaviour
{
    [SerializeField]
    private Transform[] controlPoints;

    [SerializeField]
    private int resolution = 10; // Menentukan seberapa halus kurva Bezier akan digambar

    private Vector3 gizmosPosition;

    private void OnDrawGizmos()
    {
        // Pastikan ada cukup banyak control points
        if (controlPoints == null || controlPoints.Length < 4)
        {
            Debug.LogWarning("Insufficient control points for Bezier curve.");
            return;
        }

        // Gambar garis yang menghubungkan control points
        for (int i = 0; i < controlPoints.Length - 1; i++)
        {
            Gizmos.DrawLine(controlPoints[i].position, controlPoints[i + 1].position);
        }

        // Gambar kurva Bezier
        for (int i = 0; i <= resolution; i++)
        {
            float t = i / (float)resolution;
            gizmosPosition = Mathf.Pow(1 - t, 3) * controlPoints[0].position +
                3 * Mathf.Pow(1 - t, 2) * t * controlPoints[1].position +
                3 * (1 - t) * Mathf.Pow(t, 2) * controlPoints[2].position +
                Mathf.Pow(t, 3) * controlPoints[3].position;

            Gizmos.DrawSphere(gizmosPosition, 0.1f);
        }
    }
}
