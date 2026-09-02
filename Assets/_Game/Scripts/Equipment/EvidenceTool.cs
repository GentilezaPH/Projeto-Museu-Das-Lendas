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

    [SerializeField]
    private EvidenceTracker evidenceTracker;

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

        if (creature != null && creature.Data != null)
        {
            if (creature.Data.possibleEvidences.Contains(toolEvidenceType))
            {
             Debug.Log($"Evidência confirmada: {toolEvidenceType} em {creature.Data.creatureName}");
             evidenceTracker.AddEvidence(toolEvidenceType);
            }
            else
            {
                Debug.Log($"Essa ferramenta não detecta esse tipo de evidência em {creature.Data.creatureName}");
            }
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