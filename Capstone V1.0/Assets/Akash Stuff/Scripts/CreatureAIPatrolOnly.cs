using UnityEngine;
using UnityEngine.AI;

public class CreatureAIPatrolOnly : MonoBehaviour {
    public NavMeshAgent agent;

    public LayerMask groundMask;

    private Vector3 walkPoint;
    private bool walkPointSet;
    public float walkPointRange;

    private void Awake() {
        //player = GameObject.Find("Blue Enemy").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        Patrol();
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
}
