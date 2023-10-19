using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AItest : MonoBehaviour
{
    public Transform[] waypoints;
    public Transform player;
    public float Speed = 5.0f;
    public float followDistance = 3.0f;
    public float detectionRadius = 2.0f;
    public Transform soundDetectionPoint;
    //private Vector3 originalPosition;
    public LayerMask playerLayer;


    private NavMeshAgent agent;
    private int currentWaypoint = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        //FindPlayer();
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
        }

        float distance = Vector2.Distance(soundDetectionPoint.position, player.transform.position);
        if (distance <= detectionRadius)
        {
            agent.SetDestination(player.position);
        }*/
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, detectionRadius, playerLayer);

        if (playerCollider != null)
        {
            // มีผู้เล่นอยู่ในรัศมี ให้เคลื่อนที่ไปหาผู้เล่น
            agent.SetDestination(player.position);
        }
        else
        {
            // ไม่มีผู้เล่นในรัศมี ให้หาจุดล่าสุดที่ตรวจสอบแล้วค่อยกลับไปที่เดิม
            //agent.SetDestination(originalPosition);
        }
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
    private void FindPlayer()
    {
        // หาตำแหน่งของผู้เล่นและกำหนดให้เป็นเป้าหมายของ NavMesh Agent
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent.SetDestination(player.position);
    }

    private void OnDrawGizmosSelected()
    {
        // วาดวงกลมใน Scene เพื่อแสดงรัศมีการตรวจสอบ
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }



}
