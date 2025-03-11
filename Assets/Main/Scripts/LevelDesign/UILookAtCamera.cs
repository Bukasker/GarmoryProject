using UnityEngine;

public class UILookAtCamera : MonoBehaviour
{
    [SerializeField] private Canvas canvas;

    private void LateUpdate()
    {
        if (Camera.main == null || canvas == null) return;

        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
    }
}
