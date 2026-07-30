using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Creature", menuName = "MuseuDasLendas/CreatureData")]
public class CreatureData : ScriptableObject

{
    [Header("Identidade")]
    public string creatureName;

    [TextArea(2, 4)]
    public string habitatDescription;

    [Header("Comportamento/IA")]
    [TextArea(2, 4)]
    public string behaviorDescription;

    [Header("Papel narrativo/Estilo")]
    [TextArea(2, 4)]
    public string styleMonster;

    [Range(0, 4)]
    public int agressivenessLevel;

    [Header("Evidências")]
    public List<EvidenceType> possibleEvidences;

    [Header("Captura")]
    public TrapType suggestedTrap;
    
    [TextArea(2, 4)]
    public string weaknessOrBait;
    
    [Header("Mecânica Exclusiva")]
    [TextArea(2, 4)]
    public string uniqueMechanicNotes;

    [Header("Fidelidade ao folclore")]
    [TextArea(2, 4)]
    public string folkloreNotes;



}