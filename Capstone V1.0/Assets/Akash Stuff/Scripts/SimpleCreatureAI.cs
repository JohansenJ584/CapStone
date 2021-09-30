using UnityEngine;
using UnityEngine.AI;

public class SimpleCreatureAI : MonoBehaviour
{
    public NavMeshAgent agent;
    private Transform creature;
    private float closestCreatureDistance;
    private Collider[] creatureColliders;

    public LayerMask groundMask, creatureMask;

    private Vector3 walkPoint;
    private bool walkPointSet;
    public float walkPointRange;

    public float timeBetweenActions;
    private bool alreadyActed;

    public float sightRange, actionRange;
    private bool creatureInSightRange, creatureInActionRange;

    private void Awake() {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        creatureInSightRange = Physics.CheckSphere(transform.position, sightRange, creatureMask);
        creatureInActionRange = Physics.CheckSphere(transform.position, actionRange, creatureMask);

        if (creatureInActionRange) {
            creatureColliders = Physics.OverlapSphere(transform.position, actionRange, creatureMask);
        }
        else {
            creatureColliders = Physics.OverlapSphere(transform.position, sightRange, creatureMask);
        }

        if (creatureColliders != null && creatureColliders.Length > 0) {
            closestCreatureDistance = Mathf.Infinity;
            foreach (Collider collider in creatureColliders) {
                if (transform.position.magnitude - collider.transform.position.magnitude < closestCreatureDistance) {
                    closestCreatureDistance = transform.position.magnitude - collider.transform.position.magnitude;
                    creature = collider.transform;
                }
            }
        }

        if (!creatureInSightRange && !creatureInActionRange) {
            Patrol();
        }

        if (creatureInSightRange && !creatureInActionRange) {
            Approach();
        }

        if (creatureInSightRange && creatureInActionRange) {
            Act();
        }
    }

    private void Patrol() {
        if (!walkPointSet) {
            SearchWalkPoint();
        }

        if (walkPointSet) {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f) {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint() {
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, groundMask)) {
            walkPointSet = true;
        }
    }

    private void Approach() {
        agent.SetDestination(creature.position);
    }

    private void Act() {
        agent.SetDestination(transform.position);
        transform.LookAt(creature);

        if (!alreadyActed) {
            // action code here

            alreadyActed = true;
            Invoke(nameof(ResetAction), timeBetweenActions);
        }
    }

    private void ResetAction() {
        alreadyActed = false;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, actionRange);
    }
}
