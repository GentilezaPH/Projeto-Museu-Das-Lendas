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

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();

    }

    private void OnEnable()
    {
        moveAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
    }

    private void Update()
    {
        moveInput = moveAction.action.ReadValue<Vector2>();

        Vector3 moveDirection = new Vector3(moveInput.x, 0f, moveInput.y);
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }





}