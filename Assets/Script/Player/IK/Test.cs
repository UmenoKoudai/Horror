using UnityEngine;

public class Test : MonoBehaviour
{
    Vector3 cameraPosition;

    void Update()
    {
        Vector3 point = Camera.main.ScreenToWorldPoint(Camera.main.transform.forward);
        cameraPosition = Vector3.Scale(point, transform.position).normalized;
        transform.position = cameraPosition;
    }
}
