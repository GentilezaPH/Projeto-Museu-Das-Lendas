using UnityEngine;

public class TrapBase : MonoBehaviour
{
    [SerializeField]
    private TrapType trapType;

    [SerializeField]
    private bool isActive = true;

    private void OnTriggerEnter(Collider other)
    {
        if (!isActive)
        {
            return;
        }

        CreatureController creature = other.GetComponent<CreatureController>();

        if(creature != null && creature.Data != null)
        {
            if(creature.Data.suggestedTrap == trapType)
            {
                Debug.Log($"{creature.Data.creatureName} foi capturado pela {trapType}!");
                isActive = false;
            }
            else
            {
                Debug.Log($"{creature.Data.creatureName} passou pela armadilha, mas essa não é a armadilha certa.");
            } 
        }
    }
}