using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AItest : MonoBehaviour
{
    public Transform[] waypoints; // Waypoints ที่ AI จะตาม
    public Transform player; // Player
    public float moveSpeed = 5.0f;
    public float followDistance = 3.0f; // ระยะที่ Player ต้องอยู่ใกล้ AI ถึงจะตาม
    


    private NavMeshAgent agent;
    private int currentWaypoint = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GoToNextWaypoint();
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);

        if (Vector3.Distance(transform.position, player.position) <= followDistance)
        {
            // Player อยู่ใกล้มาก โยนไปหา Player
            agent.SetDestination(player.position);
        }
        else
        {
            // Player อยู่ไกล ไปตามเส้นทาง
            agent.SetDestination(waypoints[currentWaypoint].position);
        }

        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            GoToNextWaypoint();
        }
    }

    void GoToNextWaypoint()
    {
        if (waypoints.Length == 0) return;

        agent.SetDestination(waypoints[currentWaypoint].position);
        currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
    }
}
