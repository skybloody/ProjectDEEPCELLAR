using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineofSightplayer : MonoBehaviour
{
    public float viewDistance = 10f;
    public float viewAngle = 90f;
    public LayerMask enemyLayer;
    bool playerSeesEnemy = false;


    private void Update()
    {
        // ตรวจสอบระยะการมองและมุมการมอง
        Vector3 playerPosition = transform.position;
        Collider2D[] enemies = Physics2D.OverlapCircleAll(playerPosition, viewDistance, enemyLayer);
        bool playerSeesEnemy = false;

        foreach (Collider2D enemyCollider in enemies)
        {
            Transform enemyTransform = enemyCollider.transform;

            // ตรวจสอบระยะห่างระหว่าง player และ enemy
            float distanceToEnemy = Vector2.Distance(playerPosition, enemyTransform.position);

            // ตรวจสอบมุมระหว่าง player และ enemy
            Vector2 directionToEnemy = (enemyTransform.position - playerPosition).normalized;
            float angleToEnemy = Vector2.Angle(transform.up, directionToEnemy);

            if (distanceToEnemy <= viewDistance && angleToEnemy <= viewAngle / 2f)
            {
                // มองเห็นศัตรู ทำอะไรกับศัตรูเช่นการแสดงผลหรืออื่น ๆ
                Debug.Log("Player มองเห็นศัตรู");
                playerSeesEnemy = true;
            }
        }

        if (!playerSeesEnemy)
        {
            // ถ้าไม่มองเห็นศัตรู
            Debug.Log("Player ไม่มองเห็นศัตรู");
        }
    }
}



