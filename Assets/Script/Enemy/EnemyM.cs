using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using UnityEngine;
using UnityEngine.AI;

public class EnemyM : MonoBehaviour
{
    public Transform player;
    public Transform DetectionPoint;
    public Transform[] waypoints;

    public float Speed = 5.0f;
    public float followDistance = 3.0f;
    public float detectionRadius = 2.0f;

    public LayerMask playerLayer;
    private Vector3 originalPosition;
    private Vector3 lastKnownPosition;
    private Vector2 lastMoveDirection;
    private int currentWaypointIndex;

    private Animator anim;
    private Rigidbody2D rb;
    private NavMeshAgent agent;
    private AudioSource audioSource;
    private bool PlayerHide;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        agent.speed = Speed;
        originalPosition = transform.position;
        lastKnownPosition = originalPosition;

        waypoints = GameObject.FindGameObjectsWithTag("Waypoint")
            .Select(waypoint => waypoint.transform)
            .OrderBy(waypoint => waypoint.GetSiblingIndex())
            .ToArray();

        currentWaypointIndex = 0; // กำหนด Waypoint แรกเป็น Waypoint 0
        SetDestinationToWaypoint();
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        Animante();
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, playerLayer);
        if (hitColliders.Length > 0)
        {
            // มีผู้เล่นอยู่ในรัศมี ให้เคลื่อนที่ไปหาผู้เล่น
            anim.SetBool("isWalking", true);
            agent.speed = 10f;
            lastKnownPosition = player.position;
            agent.SetDestination(player.position);
        }
        else
        {
            if (agent.remainingDistance < 0.1f) // ถ้าศัตรูเคลื่อนที่มาถึง Waypoint ปัจจุบัน
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length; // เลื่อก Waypoint ถัดไป
                SetDestinationToWaypoint(); // ตั้งค่า NavMeshAgent ไปยัง Waypoint ใหม่
            }
        }
        if (!PlayerHide)
        {
            // ตรวจสอบการชนกับ Player ปกติ
        }
        else
        {
            // ไม่ตรวจสอบการชนกับ Player ที่ถูกซ่อน
            Physics2D.IgnoreLayerCollision(gameObject.layer, playerLayer, true);
        }

    }

    void SetDestinationToWaypoint()
    {
        agent.SetDestination(waypoints[currentWaypointIndex].position); // ตั้งค่า NavMeshAgent ไปยัง Waypoint ปัจจุบัน
    }

    void Animante()
    {
        anim.SetFloat("MoveX", agent.velocity.x);
        anim.SetFloat("MoveY", agent.velocity.y);
        anim.SetFloat("MoveMagnitude", agent.velocity.magnitude);
    }
    
    private void OnDrawGizmosSelected()
    {
        // วาดวงกลมใน Scene เพื่อแสดงรัศมีการตรวจสอบ
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
