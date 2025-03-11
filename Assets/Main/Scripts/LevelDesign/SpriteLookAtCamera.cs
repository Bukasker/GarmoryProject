using UnityEngine;

public class SpriteLookAtCamera : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    private void LateUpdate()
    {
        if (mainCamera == null) return;

        transform.forward = mainCamera.transform.forward;
    }
}
