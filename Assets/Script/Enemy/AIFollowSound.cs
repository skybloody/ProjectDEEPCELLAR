using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIFollowSound : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    public float suspicionDistance = 5.0f;
    public float currentSuspicion = 0.0f;
    private AudioSource playerAudioSource;
    

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        playerAudioSource = player.GetComponent<AudioSource>();
    }


    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= suspicionDistance)
        {
            
            agent.SetDestination(player.position);
        }
        else
        {
           
            agent.ResetPath();
        }
    }
    public void IncreaseSuspicion(float amount)
    {
        // เพิ่มค่าสงสัย
        currentSuspicion += amount;
    }
}
