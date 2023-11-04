using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightConTroller : MonoBehaviour
{
    public Light2D _light;

    public float MinTime;
    public float MaxTime;
    public float Timer;

    public AudioSource AS;
    public AudioClip lightAu;

    private void OnTriggerEnter(Collider other)
    {
        // ตรวจสอบว่า collider ที่ชนเข้ามาคือ player หรือไม่

        if (other.CompareTag("Player"))
        {
            Timer = Random.Range(MinTime, MaxTime);

            if (Timer > 0)
                Timer -= Time.deltaTime;

            if (Timer < 0)
            {
                _light.enabled = !_light.enabled;
                Timer = Random.Range(MinTime, MaxTime);
                AS.PlayOneShot(lightAu);
            }
            TurnOnLight();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // ตรวจสอบว่า collider ที่เคลื่อนออกจาก trigger นี้คือ player หรือไม่
        if (other.CompareTag("Player"))
        {
            // ใส่โค้ดที่คุณต้องการให้เกิดขึ้นเมื่อ player ไม่ชนกับ trigger นี้
            // เช่น การปิดแสงหรือหยุดเล่นเสียง
            // ตัวอย่าง: เรียกฟังก์ชันปิดแสง
            TurnOffLight();
        }
    }

    // ตัวอย่างฟังก์ชันเปิดแสง
    private void TurnOnLight()
    {
        // เขียนโค้ดที่เปิดแสง
        // เช่น:
        // lightComponent.enabled = true;
    }

    // ตัวอย่างฟังก์ชันปิดแสง
    private void TurnOffLight()
    {
        // เขียนโค้ดที่ปิดแสง
        // เช่น:
        // lightComponent.enabled = false;
    }
}
