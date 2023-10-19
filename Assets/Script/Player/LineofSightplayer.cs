using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineofSightplayer : MonoBehaviour
{
    public float fovAngle;
    public Transform fovPoint;
    public float range;
    public LayerMask Obstacle;
    public LayerMask EnemyLayer;
    public List<Transform> enemies;

    

    void Update()
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
    }
       
    
}
