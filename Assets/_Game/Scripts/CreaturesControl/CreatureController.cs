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

    /*  bloco de controle de Parado do Mob  */

    private void HandleIdleState()
    {

    }


    /*  bloco de controle de VAGANDO do Mob  */


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
        
        if (playerTransform != null && Vector3.Distance(transform.position, playerTransform.position) < huntRadius)
        {
            currentState = CreatureState.Hunting;
        }
    } 



    private void PickNewWanderTarget()
    {
        Vector2 randomCircle = Random.insideUnitCircle * wanderRadius;
        wanderTarget = transform.position + new Vector3(randomCircle.x, 0f, randomCircle.y);

    }



    /*  bloco de controle de Investigando do Mob  */


    [SerializeField]
    private float investigateSpeed = 3f;

    [SerializeField]
    private float detectionRadius = 15f;

    [SerializeField]
    private Vector3 investigationPoint;


    private void HandleInvestigatingState()
    {
        float distanceToPoint = Vector3.Distance(transform.position, investigationPoint);

        transform.position = Vector3.MoveTowards(transform.position, investigationPoint, investigateSpeed * Time.deltaTime);


        if (distanceToPoint < 0.5f)
        {
            currentState = CreatureState.Wandering;
        }

        if (playerTransform != null && Vector3.Distance(transform.position, playerTransform.position) < huntRadius)
        {
            currentState = CreatureState.Hunting;
        }
    }


    /*  bloco de controle de Caçando do Mob  */

    [SerializeField]
    private float huntSpeed = 5f;

    [SerializeField]
    private float huntRadius = 8f;

    private void HandleHuntingState()
    {
        if (playerTransform == null)
        {
            currentState = CreatureState.Wandering;
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, huntSpeed * Time.deltaTime);

        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        if (distanceToPlayer > detectionRadius)
        {
            currentState = CreatureState.Wandering;
            PickNewWanderTarget();
        }
    }
    /*  bloco de controle de Fuga do Mob  */


    [SerializeField]
    private float retreatSpeed = 4f;

    [SerializeField]
    private float retreatDistance = 10f;

    [SerializeField]
    private float safeDistance = 12f;



    private void HandleRetreatingState()
    {
        if (playerTransform == null)
    {
        currentState = CreatureState.Wandering;
        PickNewWanderTarget();
        return;
    }

    Vector3 fleeDirection = (transform.position - playerTransform.position).normalized;
    Vector3 fleeTarget = transform.position + fleeDirection * retreatDistance;

    transform.position = Vector3.MoveTowards(transform.position, fleeTarget, retreatSpeed * Time.deltaTime);

    float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
    if (distanceToPlayer > safeDistance)
    {
        currentState = CreatureState.Wandering;
        PickNewWanderTarget();
    }
    }
}




