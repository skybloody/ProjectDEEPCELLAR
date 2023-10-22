using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public Transform[] waypoints; // Waypoints ที่ AI จะตาม
    public Transform player; // Player
    public float moveSpeed = 5.0f;
    public float followDistance = 3.0f; // ระยะที่ Player ต้องอยู่ใกล้ AI ถึงจะตาม
    public AudioClip DetectionSound;

    private AudioSource audioSource;
    private NavMeshAgent agent;
    private int currentWaypoint = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // หาทิศทางไปยังผู้เล่นและเคลื่อนที่ศัตรูไปหาผู้เล่น
            Vector3 playerPosition = other.transform.position;
            agent.SetDestination(playerPosition);
        }
    }

}
