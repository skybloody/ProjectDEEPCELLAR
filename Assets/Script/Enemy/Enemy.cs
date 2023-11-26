using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowPlayer : MonoBehaviour
{
    public LayerMask playerLayer;
    public Transform player;  
    private NavMeshAgent agent;
    private bool PlayerHide;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        // ตรวจสอบระยะห่างระหว่างศัตรูและผู้เล่น
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // หากระยะห่างน้อยกว่าหรือเท่ากับระยะที่ต้องการ
        if (distanceToPlayer <= 2f)  // 10f คือระยะที่ต้องการให้ติดตาม
        {
            anim.SetBool("isWalking", true);
            // ตั้งค่าตำแหน่งที่ต้องการให้ศัตรูติดตาม
            agent.SetDestination(player.position);
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
    void Animante()
    {
        anim.SetFloat("MoveX", agent.velocity.x);
        anim.SetFloat("MoveY", agent.velocity.y);
        anim.SetFloat("MoveMagnitude", agent.velocity.magnitude);
    }
}