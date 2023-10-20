using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class AItest : MonoBehaviour
{
    //=====================================//
    public Transform player;
    public Transform DetectionPoint;
    public Transform[] waypoints;
    //=====================================//
    public float Speed = 5.0f;
    public float followDistance = 3.0f;
    public float detectionRadius = 2.0f;
    //=====================================//
    public LayerMask playerLayer;
    private Vector3 originalPosition;
    private Vector3 lastKnownPosition;
    private int currentWaypointIndex;
    //=====================================//
    private Animator myAnim;
    private NavMeshAgent agent;
    private bool PlayerHide;

    //=====================================//
    //private int currentWaypoint = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        originalPosition = transform.position;
        lastKnownPosition = originalPosition;

        waypoints = GameObject.FindGameObjectsWithTag("Waypoint")
            .Select(waypoint => waypoint.transform)
            .OrderBy(waypoint => waypoint.GetSiblingIndex())
            .ToArray();

        currentWaypointIndex = 0; // กำหนด Waypoint แรกเป็น Waypoint 0
        SetDestinationToWaypoint();
        //GoToNextWaypoint();
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);

        /*if (Vector3.Distance(transform.position, player.position) <= followDistance)
        {

            agent.SetDestination(player.position);
        }
        else
        {
            
            agent.SetDestination(waypoints[currentWaypoint].position);
        }

        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            GoToNextWaypoint();
        }*/

        /*float distance = Vector2.Distance(soundDetectionPoint.position, player.transform.position);
        if (distance <= detectionRadius)
        {
            agent.SetDestination(player.position);
        }*/
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, playerLayer);

        if (!PlayerHide)
        {
            // ตรวจสอบการชนกับ Player ปกติ
        }
        else
        {
            // ไม่ตรวจสอบการชนกับ Player ที่ถูกซ่อน
            Physics2D.IgnoreLayerCollision(gameObject.layer, playerLayer, true);
        }


        if (hitColliders.Length > 0)
        {
            // มีผู้เล่นอยู่ในรัศมี ให้เคลื่อนที่ไปหาผู้เล่น
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
    }
    void SetDestinationToWaypoint()
    {
        agent.SetDestination(waypoints[currentWaypointIndex].position); // ตั้งค่า NavMeshAgent ไปยัง Waypoint ปัจจุบัน
    }

    /*void GoToNextWaypoint()
    {
        if (waypoints.Length == 0) return;

        agent.SetDestination(waypoints[currentWaypoint].position);
        currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
    }*/

    /*void OnTriggerEnter2D(Collider2D other)
    {
        // ตรวจสอบว่า Collider 2D ที่มาสังเคราะห์เป็น Collider 2D ของ Player
        if (other.CompareTag("Player"))
        {
            // ตรวจสอบระยะห่างระหว่างตำแหน่งตรงกลางของ Circle Collider 2D และตำแหน่งของ Player
            float distance = Vector2.Distance(soundDetectionPoint.position, other.transform.position);

            // ถ้าระยะห่างน้อยกว่าหรือเท่ากับรัศมีตรวจสอบ
            if (distance <= detectionRadius)
            {
                agent.SetDestination(player.position);
            }
        }
    }*/


    private void OnDrawGizmosSelected()
    {
        // วาดวงกลมใน Scene เพื่อแสดงรัศมีการตรวจสอบ
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }



}
