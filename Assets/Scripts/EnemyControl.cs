using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public List<Transform> wayPoints = new List<Transform>();
    private Transform targetWayPoint;
    public Transform player;
    private int targetWayPointIndex;
    private int lastWayPointIndex;
    private float minDistance = 0.1f;
    private float movementSpeed = 3.0f;
    public float radius;
    private Animator anim;
    private enum State { Walking, Running }
    private State state;
    void Start()
    {
        targetWayPoint = wayPoints[targetWayPointIndex];
        lastWayPointIndex = wayPoints.Count - 1;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        anim.SetInteger("state", (int)state);

        float movementStep = movementSpeed * Time.deltaTime;
        float playerDistance = Vector2.Distance(player.position, transform.position);

        Vector3 directionToTarget = targetWayPoint.position - transform.position;
        Vector3 playerToTarget = player.position - transform.position;
        Debug.DrawRay(transform.position, transform.forward * 50f, Color.green, 0f);
        Debug.DrawRay(transform.position, directionToTarget, Color.red, 0f);
        float distance = Vector3.Distance(transform.position, targetWayPoint.position); // chance target wayPoint [targetenemy -> target wayPoint]
        CheckDistanceTowayPoint(distance);
        if (playerDistance < radius && !HealthState.gameOver && !UIState.iswinner) //TODO//
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, movementStep * 2f);
            FilppingTarget(playerToTarget);
            state = State.Running;  // Play animation
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, movementStep);
            FilppingPoint(directionToTarget);
            state = State.Walking;  // Play animation
        }
    }
    void CheckDistanceTowayPoint(float cuurenDistance)
    {
        if (cuurenDistance <= minDistance)
        {
            targetWayPointIndex++;
            UpdateTargetWayPoint();
        }
    }
    void UpdateTargetWayPoint()
    {
        if (targetWayPointIndex > lastWayPointIndex)
        {
            targetWayPointIndex = 0;
        }
        targetWayPoint = wayPoints[targetWayPointIndex];
    }
    void FilppingPoint(Vector3 target)
    {
        if (target.x > 1) // Right
        {
            if (transform.localScale.x == -1)
            {
                transform.localScale = new Vector3(1, 1);
            }
        }
        else if(target.x < -1) // Left
        {
            if (transform.localScale.x == 1)
            {
                transform.localScale = new Vector3(-1, 1);
            }
        }
    }
    void FilppingTarget(Vector3 targetPlayer)
    {
        if (targetPlayer.x > 1) // Right
        {
            if (transform.localScale.x == -1)
            {
                transform.localScale = new Vector3(1, 1);
            }
        }
        else if (targetPlayer.x < -1) // Left
        {
            if (transform.localScale.x == 1)
            {
                transform.localScale = new Vector3(-1, 1);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
