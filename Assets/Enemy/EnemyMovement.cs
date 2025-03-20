using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    private enum EnemyState { Patrolling, Chasing, Returning }

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float detectionRange = 5f;
    [SerializeField] private float returnRange = 7f;
    [SerializeField] private float patrolRadius = 3f;
    [SerializeField] private float patrolWaitTime = 2f;

    private Transform player;
    private Animator animator;
    private Vector3 originalPosition;
    private Vector3 patrolTarget;
    private EnemyState currentState;
    private bool isWaiting = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        originalPosition = transform.position;
        SetNewPatrolPoint();
        currentState = EnemyState.Patrolling;
    }

    private void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        switch (currentState)
        {
            case EnemyState.Patrolling:
                Patrol();
                if (distanceToPlayer <= detectionRange) currentState = EnemyState.Chasing;
                break;

            case EnemyState.Chasing:
                ChasePlayer();
                if (distanceToPlayer > returnRange) currentState = EnemyState.Returning;
                break;

            case EnemyState.Returning:
                ReturnToOriginalPosition();
                break;
        }
    }

    private void Patrol()
    {
        if (isWaiting) return;

        if (Vector3.Distance(transform.position, patrolTarget) < 0.5f)
        {
            StartCoroutine(WaitAndSetNewPatrolPoint());
        }
        else
        {
            MoveTo(patrolTarget);
        }
    }

    private IEnumerator WaitAndSetNewPatrolPoint()
    {
        isWaiting = true;
        animator.SetBool("isMoving", false);
        yield return new WaitForSeconds(patrolWaitTime);
        SetNewPatrolPoint();
        isWaiting = false;
    }

    private void SetNewPatrolPoint()
    {
        Vector2 randomPoint = Random.insideUnitCircle * patrolRadius;
        patrolTarget = originalPosition + new Vector3(randomPoint.x, 0, randomPoint.y);
    }

    private void ChasePlayer()
    {
        MoveTo(player.position);
    }

    private void ReturnToOriginalPosition()
    {
        if (Vector3.Distance(transform.position, originalPosition) < 0.5f)
        {
            currentState = EnemyState.Patrolling;
        }
        else
        {
            MoveTo(originalPosition);
        }
    }

    private void MoveTo(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
        transform.LookAt(target);
        animator.SetBool("isMoving", true);
    }
}
