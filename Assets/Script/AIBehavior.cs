using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed = 2.0f;
    private int currentWaypoint = 0;
    private bool isAvoidingObstacle = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveToWaypoint(waypoints[currentWaypoint]));
    }

    // Update is called once per frame
    private IEnumerator MoveToWaypoint(Transform waypoint)
    {
        while (Vector2.Distance(transform.position, waypoint.position) > 0.1f)
        {
            if (!isAvoidingObstacle)
            {
                
                transform.position = Vector2.MoveTowards(transform.position, waypoint.position, moveSpeed * Time.deltaTime);
            }

            yield return null;
        }


        currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        Transform nextWaypoint = waypoints[currentWaypoint];
        StartCoroutine(MoveToWaypoint(nextWaypoint));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            
            isAvoidingObstacle = true;
            StartCoroutine(AvoidObstacle());
        }
    }
    private IEnumerator AvoidObstacle()
    {
       
        Vector2 newDirection = Random.insideUnitCircle.normalized;
        Vector2 currentPosition = transform.position;
        Vector2 targetPosition = currentPosition + newDirection * 2.0f; // ย้ายไปข้างหน้า

        while (Vector2.Distance(currentPosition, targetPosition) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            currentPosition = transform.position;
            yield return null;
        }

        
        isAvoidingObstacle = false;
    }
}
