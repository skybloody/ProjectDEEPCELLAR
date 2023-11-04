using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIFollowSound : MonoBehaviour
{
    public Transform target; // ตำแหน่งเป้าหมาย (ผู้เล่น)
    private NavMeshAgent navMeshAgent; // อ้างอิง NavMeshAgent สำหรับเคลื่อนที่

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (target == null)
        {
            // ถ้าไม่มีเป้าหมายที่กำหนดให้ใช้ GameObject ที่มี Tag "Player" เป็นเป้าหมาย
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        // ตรวจสอบว่ามีเป้าหมายหรือไม่
        if (target == null)
        {
            Debug.LogWarning("ไม่พบเป้าหมาย!");
            return;
        }

        // ตั้งค่าตำแหน่งเป้าหมาย
        navMeshAgent.SetDestination(target.position);

        // เปลี่ยนเป้าหมายหากผู้เล่นยิ่งไปห่างเกินระยะที่กำหนด (เช่น ระยะ 10 เมตร)
        if (Vector3.Distance(transform.position, target.position) > 10f)
        {
            target = null; // เป้าหมายห่างเกินไป กำหนดให้ไม่มีเป้าหมาย
        }
    }
}
