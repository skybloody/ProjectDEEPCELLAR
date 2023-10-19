using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float Speed;
    
    private NavMeshAgent agent;    


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

    }

}