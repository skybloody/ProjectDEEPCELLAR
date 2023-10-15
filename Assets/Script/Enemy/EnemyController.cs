using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    Hiding hiding;

    

    private Animator myAnim;
    public float speed;
    public float minRange;
    public float maxRange;
    public Transform target;
    public Transform homePos;

    public Transform[] waypoints; // Waypoints ที่ AI จะตาม
    public Transform player; // Player
    public float moveSpeed = 5.0f;
    public float followDistance = 3.0f; // ระยะที่ Player ต้องอยู่ใกล้ AI ถึงจะตาม

    private NavMeshAgent agent;
    private int currentWaypoint = 1;

    void Start()
    {
        
        myAnim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        player = FindObjectOfType<PlayerMovement>().transform;
        GoToNextWaypoint();
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        Destination();
        AvoidWalls();

        if (IsPlayerVisible(maxRange))
        {
            FollowPlayer();
        }
        else
        {
            AvoidWalls();
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= followDistance)
        {
            agent.SetDestination(player.position);
        }
    }

    public void Destination() 
    {
        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
        {
            FollowPlayer();
        }
        else if (Vector3.Distance(target.position, transform.position) >= maxRange)
        {
            GoHome();
        }

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

    void AvoidWalls()
    {
       /* RaycastHit hit;
        if (Physics.Raycast(transform.position, player.position - transform.position, out hit, wallDetectionDistance))
        {
            if (hit.collider.tag == "Wall")
            {
                // มีกำแพงหรืออุปสรรคอยู่ระหว่าง AI กับ Player
                // ให้ AI หลบหลังกำแพง
                Vector3 avoidDirection = Vector3.Cross(hit.normal, Vector3.up);
                Vector3 targetPosition = transform.position + avoidDirection * 3.0f; // ย้ายไปข้างหน้าหลีกหนี
                agent.SetDestination(targetPosition);
            }
        }*/
    }

    void GoToNextWaypoint()
    {
        if (waypoints.Length == 0) return;

        agent.SetDestination(waypoints[currentWaypoint].position);
        currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
    }

    public void FollowPlayer()
    {
        myAnim.SetBool("isMoving", true);
        myAnim.SetFloat("moveX", target.position.x - transform.position.x);
        myAnim.SetFloat("moveY", target.position.y - transform.position.y);
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    public void GoHome()
    {
        //myAnim.SetFloat("moveX", homePos.position.x - transform.position.x);
        //myAnim.SetFloat("moveY", homePos.position.y - transform.position.y);
        transform.position = Vector3.MoveTowards(transform.position, homePos.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, homePos.position) == 0)
        {
            myAnim.SetBool("isMoving", false);
        }
    }
    bool IsPlayerVisible(float range)
    {
        Vector3 directionToPlayer = player.position - transform.position;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, directionToPlayer, out hit))
        {
            if (hit.transform == player)
            {
                return true; 
            }
        }

        return false; 
    }
}
