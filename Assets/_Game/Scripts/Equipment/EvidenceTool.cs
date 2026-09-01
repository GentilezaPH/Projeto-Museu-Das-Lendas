using UnityEngine;
using UnityEngine.InputSystem;

public class EvidenceTool : MonoBehaviour
{
    [SerializeField]
    private EvidenceType toolEvidenceType;

    [SerializeField]
    private float detectionRange = 10f;

    [SerializeField]
    private Transform cameraTransform;

    [SerializeField]
    private InputActionReference useAction;

    private void OnEnable()
    {
        useAction.action.Enable();
        useAction.action.performed += OnUsePressed;
    }

    private void OnDisable()
    {
        useAction.action.performed -= OnUsePressed;
        useAction.action.Disable();
    }

    private void OnUsePressed(InputAction.CallbackContext context)
    {
        TryDetectEvidence();
    }

    private void TryDetectEvidence()
    {
        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, detectionRange))
        {
            CreatureController creature = hit.collider.GetComponent<CreatureController>();

            if (creature != null)
            {
                Debug.Log($"Raio acertou uma criatura: {creature.gameObject.name}");
            }
            else
            {
                Debug.Log("Raio acertou algo, mas não é uma criatura.");
            }
        }
        else
        {
            Debug.Log("Nada detectado no alcance.");
        }
    }
}