using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySoundDetection : MonoBehaviour
{
    public AudioSource enemyAudioSource; // AudioSource ของศัตรู
    public float detectionRange = 10f; // ระยะทางสูงสุดที่ศัตรูจะตรวจสอบเสียง
    public float detectionThreshold = 0.5f; // ค่าเกณฑ์ของการตรวจสอบเสียง

    void Update()
    {
        // ตรวจสอบระยะทางระหว่างศัตรูและผู้เล่น
        float distance = Vector3.Distance(transform.position, PlayerPosition());

        if (distance <= detectionRange)
        {
            // ตรวจสอบเสียงที่เล่นโดยศัตรู
            if (enemyAudioSource.volume >= detectionThreshold)
            {
                // ศัตรูตรวจสอบเสียงของผู้เล่น
                // ทำสิ่งที่คุณต้องการให้ศัตรูทำเมื่อตรวจสอบเสียงของผู้เล่น
            }
        }
    }

    Vector3 PlayerPosition()
    {
        // คืนค่าตำแหน่งปัจจุบันของผู้เล่น
        // คุณอาจต้องแก้ไขเมื่อคุณใช้ตำแหน่งผู้เล่นจริง ๆ ในเกมของคุณ
        return Vector3.zero;
    }
}
