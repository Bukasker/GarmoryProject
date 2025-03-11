using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float mouseSensitivityX = 5f;
    [SerializeField] private float mouseSensitivityY = 2f;
    [SerializeField] private float cameraBlockDegree = 45;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterController characterController;

    private Vector3 moveDirection;
    private float rotationX = 0f;
    private bool isControlEnabled = true;

    private void Update()
    {
        if (!isControlEnabled) return;

        HandleMovement();
        HandleMouseLook();

        if(EquipmentManager.Instance.weaponHolder.sprite != null)
        {
            HandleAttack();
        }
    }
    private void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        characterController.Move(move * moveSpeed * Time.deltaTime);

        float speed = move.magnitude * moveSpeed;
        animator.SetFloat("Speed", speed, 0.1f, Time.deltaTime);
    }
    private void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY;

        transform.Rotate(Vector3.up * mouseX);

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -cameraBlockDegree, cameraBlockDegree);
        cameraTransform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    }
    private void HandleAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
        }
    }
    public void DisableControls()
    {
        isControlEnabled = false;
    }

    public void EnableControls()
    {
        isControlEnabled = true;
    }
}
