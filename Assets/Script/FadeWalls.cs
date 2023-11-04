using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeWalls : MonoBehaviour
{
    public Transform player;  // ใส่วัตถุของผู้เล่นที่คุณต้องการตรวจสอบระยะห่าง

    public float cullingDistance = 10.0f;  // ระยะห่างที่เมื่อผู้เล่นเข้าใกล้มากกว่าจะทำการลดลง

    private SpriteRenderer spriteRenderer;  // ใช้สำหรับ SpriteRenderer ของวัตถุ

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();  // ดึงคอมโพเนนต์ SpriteRenderer ที่เชื่อมกับวัตถุนี้
    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(player.position, transform.position);

            if (distanceToPlayer < cullingDistance)
            {
                // ถ้าผู้เล่นเข้าใกล้มากกว่าระยะห่างที่กำหนด จะทำการลดลง
                spriteRenderer.enabled = false;
            }
            else
            {
                // ถ้าผู้เล่นห่างออกไปมากกว่าระยะห่างที่กำหนด จะทำการแสดงวัตถุ
                spriteRenderer.enabled = true;
            }
        }
    }
}

