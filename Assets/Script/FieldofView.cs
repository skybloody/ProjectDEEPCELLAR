using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldofView : MonoBehaviour
{

    public float viewRadius = 10f; 
    [Range(0, 360)]
    public float viewAngle = 90f; 

    public LayerMask targetMask; 
    public LayerMask obstacleMask; 

    [HideInInspector]
    public Transform visibleTarget; 

    private void Start()
    {
        
        StartCoroutine("FindVisibleTargets");
    }

    IEnumerator FindVisibleTargets()
    {
        while (true)
        {
            //FindVisibleTargets();
            yield return new WaitForSeconds(0.2f); 
        }
    }

   /* void FindVisibleTargets()
    {
        Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector2 dirToTarget = (target.position - transform.position).normalized;

            if (Vector2.Angle(transform.up, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector2.Distance(transform.position, target.position);

                
                if (!Physics2D.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    visibleTarget = target; 
                    
                }
            }
        }
    }*/

    public Vector2 DirFromAngle(float angleInDegrees, bool isGlobal)
    {
        if (!isGlobal)
        {
            angleInDegrees += transform.eulerAngles.z;
        }
        return new Vector2(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
