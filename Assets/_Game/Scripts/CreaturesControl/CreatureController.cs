using UnityEngine;

public class CreatureController : MonoBehaviour
{
    [SerializeField]
    private CreatureData data;

    [SerializeField]
    private CreatureState currentState = CreatureState.Idle;

    private Transform playerTransform;

    private void Awake()
    {
        if(data == null)
        {
            Debug.LogError($"{gameObject.name}: CreatureData não foi atribuído no Inspector!");
        
        }

    }

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if(playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
        else
        {
            Debug.LogError($"{gameObject.name}: Nenhum objeto com tag 'Player' foi encontrado na cena.");
        }

        PickNewWanderTarget();
    }

    private void Update()
    {
        switch (currentState)
        {
            case CreatureState.Idle:
               HandleIdleState();
               break;
            
            case CreatureState.Wandering:
               HandleWanderingState();
               break;
            
            case CreatureState.Hunting:
               HandleHuntingState();
               break;

            case CreatureState.Investigating:
               HandleInvestigatingState();
               break;

            case CreatureState.Retreating:
               HandleRetreatingState();
               break;
        }
    }

    private void HandleIdleState()
    {

    }

    [SerializeField]
    private float wanderSpeed = 2f;

    [SerializeField]
    private float wanderRadius = 10f;

    private Vector3 wanderTarget;

    private void HandleWanderingState()
    {
        float distanceToTarget = Vector3.Distance(transform.position, wanderTarget);
        if(distanceToTarget < 0.5f)
        {
            PickNewWanderTarget();
        }

        transform.position = Vector3.MoveTowards(transform.position, wanderTarget, wanderSpeed * Time.deltaTime);
        
    }

    private void PickNewWanderTarget()
    {
        
    }

}