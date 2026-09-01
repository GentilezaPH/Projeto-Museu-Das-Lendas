using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private InputActionReference moveAction;

    private CharacterController characterController;
    private Vector2 moveInput;

    [SerializeField]
    private float lookSensitivity = 0.1f;

    [SerializeField]
    private InputActionReference lookAction;

    [SerializeField]
    private Transform cameraTransform;

    private float verticalRotation;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();

    }

    private void OnEnable()
{
    moveAction.action.Enable();
    lookAction.action.Enable();
}

    private void OnDisable()
{
    moveAction.action.Disable();
    lookAction.action.Disable();
}
    private void Update()
{
    moveInput = moveAction.action.ReadValue<Vector2>();
    Vector3 moveDirection = new Vector3(moveInput.x, 0f, moveInput.y);
    characterController.Move(transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);

    Vector2 lookInput = lookAction.action.ReadValue<Vector2>();

    transform.Rotate(Vector3.up * lookInput.x * lookSensitivity);

    verticalRotation -= lookInput.y * lookSensitivity;
    verticalRotation = Mathf.Clamp(verticalRotation, -80f, 80f);
    cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
}



}