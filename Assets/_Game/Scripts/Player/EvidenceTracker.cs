using UnityEngine;
using System.Collections.Generic;

public class EvidenceTracker : MonoBehaviour
{
    private List<EvidenceType> collectedEvidences = new List<EvidenceType>();

    public void AddEvidence(EvidenceType evidence)
    {
        if(!collectedEvidences.Contains(evidence))
        {
            collectedEvidences.Add(evidence);
            Debug.Log($"Nova evidência registrada: {evidence}. Total: {collectedEvidences.Count}");
        }
        else
        {
            Debug.Log($"Evidência {evidence} já havia sido coletada.");
        }
    }

    public List<EvidenceType> GetCollectedEvidences()
    {
        return collectedEvidences;
    }
}