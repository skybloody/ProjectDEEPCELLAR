using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine : MonoBehaviour
{
    public Transform target;

    public enum EnemyState {Idle, Patrol, Chase, Attack}
    private EnemyState currentState;
    private Animator anim;
    private NavMeshAgent agent;

    void Start()
    {
        currentState = EnemyState.Idle;
        anim = GetComponent<Animator>();
        anim.SetTrigger("Idle");
        StartCoroutine(ChangeStateAfterDelay(3f, EnemyState.Patrol));
    }
    void SetState(EnemyState newState)
    {
        currentState = newState;
    }

    void IdleState()
    {
        anim.SetTrigger("Idle");
        float distanceToPlayer = Vector2.Distance(transform.position, target.transform.position);
        // ????????????????????????????????????
        float detectionRange = 5.0f;

        if (distanceToPlayer <= detectionRange)
        {
            SetState(EnemyState.Chase);
        }
        else
        {
            SetState(EnemyState.Idle);
        }
    }

    void PatrolState()
    {
        anim.SetTrigger("Walk");
    }

    void ChaseState()
    {
        anim.SetTrigger("Run");
    }

    void AttackState()
    {
        anim.SetTrigger("Attack");
    }
    void Update()
    {
        switch (currentState)
        {
            case EnemyState.Idle:
                IdleState();
                break;
            case EnemyState.Patrol:
                PatrolState();
                break;
            case EnemyState.Chase:
                ChaseState();
                break;
            case EnemyState.Attack:
                AttackState();
                break;
        }
    }
    IEnumerator ChangeStateAfterDelay(float delay, EnemyState nextState)
    {
        yield return new WaitForSeconds(delay);
        SetState(nextState);
    }
}
