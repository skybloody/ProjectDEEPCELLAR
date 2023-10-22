using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineofSightplayer : MonoBehaviour
{
    /*  public float fovAngle;
      public Transform fovPoint;
      public float range;
      public LayerMask Obstacle;
      public LayerMask EnemyLayer;
      public List<Transform> enemies;*/

    public float viewDistance = 10f; 
    public float viewAngle = 90f; 
    public LayerMask aiLayer; 
    public LayerMask obstacleLayer;
    public LayerMask playerLayer;

    private void Update()
    {
        
        Vector3 playerPosition = transform.position;
        Collider2D[] aiColliders = Physics2D.OverlapCircleAll(playerPosition, viewDistance, aiLayer);

        foreach (Collider2D aiCollider in aiColliders)
        {
            Transform aiTransform = aiCollider.transform;

           
            float distanceToAI = Vector2.Distance(playerPosition, aiTransform.position);

          
            Vector2 directionToAI = (aiTransform.position - playerPosition).normalized;
            float angleToAI = Vector2.Angle(transform.up, directionToAI);

            if (distanceToAI <= viewDistance && angleToAI <= viewAngle / 2f)
            {
               
                Debug.Log("Player มองเห็น AI");

                
                Physics2D.IgnoreLayerCollision(gameObject.layer, aiLayer, true);
            }
            else
            {
               
                Physics2D.IgnoreLayerCollision(gameObject.layer, aiLayer, false);
            }
        }
    }


    /*  void Update()
      {
          foreach (Transform enemy in enemies)
          {
              Vector2 dir = enemy.position - transform.position;
              RaycastHit2D r = Physics2D.Raycast(fovPoint.position, dir, range, Obstacle);

              if (r.collider == null)
              {
                  float angle = Vector3.Angle(dir, fovPoint.up);

                  if (angle < fovAngle / 2)
                  {
                      if (Physics2D.OverlapCircle(enemy.position, 0.1f, EnemyLayer))
                      {
                          Debug.DrawRay(fovPoint.position, dir, Color.red);
                      }
                  }
                  else
                  {


                  }
              }
          }
      }*/
}
