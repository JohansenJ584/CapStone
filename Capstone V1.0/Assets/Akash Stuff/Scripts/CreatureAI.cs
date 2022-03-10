using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class CreatureAI : MonoBehaviour {
    public NavMeshAgent agent;

    private float targetCooldownTriggeredTime, targetCooldownDuration;
    private Transform targetCreature;
    private Collider[] collidersInSightRange;
    private List<GameObject> creaturesInSightRange;

    public LayerMask groundMask, creatureMask;

    private Vector3 walkPoint;
    private bool walkPointSet, runStarted;
    public float walkPointRange;

    private Vector3 spawnPoint;
    private bool returningToSpawn, inBoundingBox;
    public float boundingBoxRange;
    private float boundingBoxEscapedTime, boundingBoxEscapedTimeLimit;

    public float timeBetweenActions;
    private bool alreadyActed;

    public float sightRange, actionRange;

    public string[] priorityCreatures, creaturesToChase, creaturesToEat, creaturesToFear;

    public bool debug;
    private bool debug1Performed = false, debug2Performed = false, debug3Performed = false, debug4Performed = false;

    private void Awake() {
        targetCooldownTriggeredTime = Time.time;
        targetCooldownDuration = 3.0f;

        boundingBoxEscapedTimeLimit = 3.0f;
        spawnPoint = transform.position;
        returningToSpawn = false;
        inBoundingBox = true;

        //agent = GetComponent<NavMeshAgent>();
        creaturesInSightRange = new List<GameObject>();
    }

    private void Update() {
        if (!returningToSpawn) {
            if (boundingBoxRange > 1) {
                if ((transform.position - spawnPoint).magnitude > boundingBoxRange) {
                    if (boundingBoxEscapedTime == 0.0f) {
                        boundingBoxEscapedTime = Time.time;
                        if (debug) { Debug.Log($"[{Time.time}] {name}: Escaped bounding box."); }
                    }
                    if (Time.time - boundingBoxEscapedTime > boundingBoxEscapedTimeLimit) {
                        returningToSpawn = true;
                    }
                }
            }

            GetCreaturesInSightRange();

            if (targetCooldownTriggeredTime < Time.time) {
                if (debug && !debug1Performed && (targetCreature = null)) {
                    Debug.Log($"[{Time.time}] {name}: Querying for creatures.");
                    debug1Performed = true;
                }
                if (creaturesInSightRange.Count > 0) {
                    targetCreature = GetTargetCreature();
                    if (targetCreature != null) {
                        if (debug && !debug2Performed) {
                            Debug.Log($"[{Time.time}] {name}: Found {targetCreature.name}.");
                            debug2Performed = true;
                        }
                        targetCooldownTriggeredTime = Time.time + targetCooldownDuration;
                        debug1Performed = false;
                    }
                }
                else {
                    if (debug) { debug2Performed = false; }
                    runStarted = false;
                    targetCreature = null;
                }
            }

            if (targetCreature != null) {
                PerformAction();
            }
            else {
                Patrol(false);
            }
        }
        else {
            ReturnToSpawn();
        }
    }

    private void GetCreaturesInSightRange() {
        creaturesInSightRange.Clear();
        collidersInSightRange = Physics.OverlapSphere(transform.position, sightRange, creatureMask);

        foreach (Collider collider in collidersInSightRange) {
            if (collider.gameObject != gameObject) {
                creaturesInSightRange.Add(collider.gameObject);
            }
        }
    }

    private Transform GetTargetCreature() {
        Transform creature;

        if (creaturesInSightRange.Count == 1) {
            return creaturesInSightRange[0].transform;
        }

        if (priorityCreatures.Length > 0) {
            creature = GetPriorityCreature();
        }
        else {
            creature = GetClosestCreature();
        }

        return creature;
    }

    private Transform GetClosestCreature() {
        float closestCreatureDistance = Mathf.Infinity;
        foreach (GameObject creature in creaturesInSightRange) {
            if (transform.position.magnitude - creature.transform.position.magnitude < closestCreatureDistance) {
                closestCreatureDistance = transform.position.magnitude - creature.transform.position.magnitude;
                return creature.transform;
            }
        }

        return null;
    }

    private Transform GetPriorityCreature() {
        float closestCreatureDistance = Mathf.Infinity;
        foreach (GameObject creature in creaturesInSightRange) {
            if (IsPriorityCreature(creature.name)) {
                if (transform.position.magnitude - creature.transform.position.magnitude < closestCreatureDistance) {
                    closestCreatureDistance = transform.position.magnitude - creature.transform.position.magnitude;
                    return creature.transform;
                }
            }
        }

        return null;
    }

    private bool IsPriorityCreature(string creature) {
        foreach (string creatureName in priorityCreatures) {
            if (creatureName.Contains(creature)) {
                return true;
            }
        }

        return false;
    }

    private void PerformAction() {
        foreach (string creature in creaturesToFear) {
            if (creature.Contains(targetCreature.name)) {
                Patrol(true);
            }
        }
        foreach (string creature in creaturesToChase) {
            if (creature.Contains(targetCreature.name)) {
                if (debug && !debug3Performed) {
                    Debug.Log($"[{Time.time}] {name}: Chasing {targetCreature.name}.");
                    debug3Performed = true;
                }
                Chase();
            }
        }
    }

    private void Chase() {
        agent.SetDestination(targetCreature.position);
        transform.LookAt(targetCreature);
    }

    private void Act() {
        agent.SetDestination(transform.position);
        transform.LookAt(targetCreature);

        if (!alreadyActed) {
            // action code here

            alreadyActed = true;
            Invoke(nameof(ResetAction), timeBetweenActions);
        }
    }

    private void ResetAction() {
        alreadyActed = false;
    }

    private void Patrol(bool runningAway) {
        if (debug) { debug3Performed = false; }

        if (runningAway && !runStarted) {
            walkPointSet = false;
            runStarted = true;
        }

        if (!walkPointSet) {
            if (runningAway) {
                SearchWalkPointOpposite();
            }
            else {
                SearchWalkPoint();
            }
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
        if (boundingBoxRange > 1) {
            Vector2 randomV = Random.insideUnitCircle * boundingBoxRange;

            walkPoint = new Vector3(spawnPoint.x + randomV.x, spawnPoint.y, spawnPoint.z + randomV.y);
        }
        else {
            float randomX = Random.Range(-walkPointRange, walkPointRange);
            float randomZ = Random.Range(-walkPointRange, walkPointRange);

            walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        }

        if (debug) {
            Debug.Log($"[{Time.time}] {name}: Patrolling to {walkPoint}.");
        }

        if (Physics.Raycast(walkPoint, -transform.up, 2f, groundMask)) {
            walkPointSet = true;
        }
    }

    private void SearchWalkPointOpposite() {
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        Vector3 locationVector = targetCreature.position - transform.position;

        walkPoint = new Vector3(transform.position.x - locationVector.x + randomX, transform.position.y, transform.position.z - locationVector.z + randomZ);

        if (debug) {
            Debug.Log($"[{Time.time}] {name}: Running away to {walkPoint}.");
        }

        if (Physics.Raycast(walkPoint, -transform.up, 2f, groundMask)) {
            walkPointSet = true;
        }
    }

    private void ReturnToSpawn() {
        if (debug && !debug4Performed) {
            Debug.Log($"[{Time.time}] {name}: Returning to spawn.");
            debug4Performed = true;
        }

        walkPoint = spawnPoint;

        agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f) {
            returningToSpawn = false;
            debug4Performed = false;
            boundingBoxEscapedTime = 0.0f;
        }

    }

    private void Stop() {
        agent.SetDestination(transform.position);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, actionRange);
        if (name == "Hunter") {
            Gizmos.color = Color.red;
        }
        else if (name == "PassiveExplorer") {
            Gizmos.color = Color.blue;
        }
        Gizmos.DrawLine(transform.position, walkPoint);
        Gizmos.DrawWireSphere(walkPoint, actionRange);
        Gizmos.DrawWireSphere(spawnPoint, boundingBoxRange);
    }
}
