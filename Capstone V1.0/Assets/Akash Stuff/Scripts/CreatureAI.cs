using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class CreatureAI : MonoBehaviour {
    public NavMeshAgent agent;

    private Transform targetCreature;
    private Collider[] collidersInSightRange;
    private List<GameObject> creaturesInSightRange;

    public LayerMask groundMask, creatureMask;

    private float targetCooldownTriggeredTime;
    public float targetCooldownDuration;

    private Vector3 walkPoint;
    private bool walkPointSet, runStarted;
    private bool destinationReached, idleStarted, idleCooldown;
    private float idleTimer, idleCooldownTimer;
    private Vector3 lastPosition;
    private float lastPositionTime, positionCheckTimer;
    public float walkPointRange;

    private Vector3 spawnPoint;
    private bool returningToSpawn;
    public float boundingBoxRange, boundingBoxEscapedTimeLimit;
    private float boundingBoxEscapedTime;

    public float timeBetweenActions;
    private bool alreadyActed;

    public float sightRange, actionRange;

    public string[] priorityCreatures, creaturesToChase, creaturesToFear;

    public bool debug;
    private bool debug1Performed = false, debug2Performed = false, debug3Performed = false, debug4Performed = false;

    private void Awake() {
        targetCooldownTriggeredTime = Time.time;

        spawnPoint = transform.position;
        returningToSpawn = false;
        destinationReached = false;
        idleStarted = false;
        idleCooldownTimer = idleTimer + 10.0f;
        positionCheckTimer = 3.0f;

        creaturesInSightRange = new List<GameObject>();
    }

    private void Update() {
        if (Time.time - lastPositionTime > positionCheckTimer) {
            if ((transform.position - lastPosition).magnitude < 1.0f) {
                walkPointSet = false;
                SearchWalkPointOpposite(walkPoint);
                lastPositionTime = Time.time;
            }
        }
        if (Time.time - idleTimer > idleCooldownTimer) {
            idleCooldown = false;
        }
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
        Transform closestCreature = null;
        foreach (GameObject creature in creaturesInSightRange) {
            Vector3 posDiff = transform.position - creature.transform.position;
            if (posDiff.magnitude < closestCreatureDistance) {
                closestCreatureDistance = posDiff.magnitude;
                closestCreature = creature.transform;
            }
        }

        return closestCreature;
    }

    private Transform GetPriorityCreature() {
        float closestCreatureDistance = Mathf.Infinity;
        float closestPriorityCreature = Mathf.Infinity;
        Transform closestCreature = null;
        Transform priorityCreature = null;
        foreach (GameObject creature in creaturesInSightRange) {
            Vector3 posDiff = transform.position - creature.transform.position;
            if (IsPriorityCreature(creature.name)) {
                if (posDiff.magnitude < closestPriorityCreature) {
                    closestPriorityCreature = posDiff.magnitude;
                    priorityCreature = creature.transform;
                }
            }
            else {
                if (posDiff.magnitude < closestCreatureDistance) {
                    closestCreatureDistance = posDiff.magnitude;
                    closestCreature = creature.transform;
                }
            }
        }

        if (priorityCreature) {
            return priorityCreature;
        }
        else {
            return closestCreature;
        }
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
        bool doingSomething = false;
        foreach (string creature in creaturesToFear) {
            if (creature.Contains(targetCreature.name)) {
                Patrol(true);
                doingSomething = true;
            }
        }
        foreach (string creature in creaturesToChase) {
            if (creature.Contains(targetCreature.name)) {
                if (debug && !debug3Performed) {
                    Debug.Log($"[{Time.time}] {name}: Chasing {targetCreature.name}.");
                    debug3Performed = true;
                }
                Vector3 posDiff = transform.position - targetCreature.position;
                if (posDiff.magnitude <= actionRange) {
                    Act();
                    doingSomething = true;
                }
                else {
                    Chase();
                    doingSomething = true;
                }
            }
        }
        if (!doingSomething) {
            Patrol(false);
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
            if (debug) {
                Debug.Log($"[{Time.time}] {name}: Interacting with {targetCreature.name}.");
            }

            alreadyActed = true;
            Invoke(nameof(ResetAction), timeBetweenActions);
        }
    }

    private void ResetAction() {
        alreadyActed = false;
    }

    private void Patrol(bool runningAway) {
        if (runningAway) {
            if (!runStarted) {
                walkPointSet = false;
                runStarted = true;
            }
            if (destinationReached) {
                destinationReached = false;
                walkPointSet = false;
            }
            if (!walkPointSet) {
                SearchWalkPointOpposite(targetCreature.position);
            }
            if (walkPointSet) {
                agent.SetDestination(walkPoint);
            }
        }
        else {
            if (destinationReached) {
                if (!idleStarted && !idleCooldown) {
                    if (debug) { Debug.Log($"[{Time.time}] {name}: Idling."); }
                    idleTimer = Time.time;
                    idleStarted = true;
                    idleCooldown = true;
                }
                else if (Time.time - idleTimer > timeBetweenActions) {
                    idleStarted = false;
                    destinationReached = false;
                    walkPointSet = false;

                    if (!walkPointSet) {
                        SearchWalkPoint();
                    }
                    if (walkPointSet) {
                        agent.SetDestination(walkPoint);
                    }
                }
                else {
                    // transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y + 1, transform.rotation.z, transform.rotation.w);
                }
            }
            else {
                if (!walkPointSet) {
                    SearchWalkPoint();
                }
                if (walkPointSet) {
                    agent.SetDestination(walkPoint);
                }
            }
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f) {
            destinationReached = true;
        }
    }

    private void SearchWalkPoint() {
        Vector3 randomV;
        if (boundingBoxRange > 1) {
            Vector2 randomV2 = Random.insideUnitCircle * boundingBoxRange;
            randomV = new Vector3(randomV2.x + transform.position.x, transform.position.y, randomV2.y + transform.position.z);
            NavMeshHit hit;
            NavMesh.SamplePosition(randomV, out hit, boundingBoxRange, NavMesh.AllAreas);
            walkPoint = hit.position;
        }
        else {
            Vector2 randomV2 = Random.insideUnitCircle * walkPointRange;
            randomV = new Vector3(randomV2.x + transform.position.x, transform.position.y, randomV2.y + transform.position.z);
            NavMeshHit hit;
            NavMesh.SamplePosition(randomV, out hit, walkPointRange, NavMesh.AllAreas);
            walkPoint = hit.position;
        }

        if (Physics.Raycast(walkPoint, -transform.up, 2f, groundMask)) {
            walkPointSet = true;

            if (debug) {
                Debug.Log($"[{Time.time}] {name}: Patrolling to {walkPoint}.");
            }
        }
    }

    private void SearchWalkPointOpposite(Vector3 targetPosition) {
        Vector2 randomV2 = Random.insideUnitCircle * walkPointRange;
        Vector3 positionDiff = transform.position - targetPosition;
        Vector3 randomV = new Vector3(randomV2.x + positionDiff.x * 3, transform.position.y, randomV2.y + positionDiff.z * 3);
        NavMeshHit hit;
        NavMesh.SamplePosition(randomV, out hit, walkPointRange, NavMesh.AllAreas);
        walkPoint = hit.position;

        if (Physics.Raycast(walkPoint, -transform.up, 2f, groundMask)) {
            walkPointSet = true;

            if (debug) {
                Debug.Log($"[{Time.time}] {name}: Running away to {walkPoint}.");
            }
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
        Gizmos.DrawWireSphere(walkPoint, 2.0f);
        Gizmos.DrawWireSphere(spawnPoint, boundingBoxRange);
    }
}
