using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowPlayer : MonoBehaviour
{
    private Animator animator;
    public float detectionRadius = 2f;
    public LayerMask playerLayer;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // ตรวจสอบว่า Player อยู่ในระยะของ Collider
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, playerLayer);
        bool isPlayerInRange = colliders.Length > 0;

        // ตั้งค่า Bool ใน Animator
        animator.SetBool("isAttacking", isPlayerInRange);

        // อื่น ๆ ที่คุณต้องการทำ...
    }
}