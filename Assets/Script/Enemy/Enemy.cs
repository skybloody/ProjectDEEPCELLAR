using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Windows;

public class Enemy : MonoBehaviour
{
    private Transform target;
    public Transform homePos;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxRange;
    [SerializeField]
    private float minRange;
    enum State {Idle, Patrol, Chase, Attack}
    State _currentState;
    NavMeshAgent _agent;
    Animator _animator;

    void Start()
    {
        target = FindObjectOfType<PlayerMovement>().transform;
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position)>= minRange)
        {
            Chase();
        }
        else if (Vector3.Distance(target.position, transform.position) >= maxRange)
        {
            GoHome();
        }
    }

    void Chase()
    {
        _animator.SetBool("isMoving", true);
        _animator.SetFloat("moveX", (target.position.x - transform.position.x));
        _animator.SetFloat("moveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
    public void GoHome()
    {
        _animator.SetFloat("moveX", (homePos.position.x - transform.position.x));
        _animator.SetFloat("moveY", (homePos.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, homePos.position, speed * Time.deltaTime);
        
        if(Vector3.Distance(transform.position, homePos.position) == 0)
        {
            _animator.SetBool("isMoving", false);
        }
    }
}
