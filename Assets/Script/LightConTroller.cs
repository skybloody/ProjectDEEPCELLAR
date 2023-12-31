﻿using System.Collections;
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
         
            TurnOffLight();
        }
    }

    
    private void TurnOnLight()
    {
  
    }

   
    private void TurnOffLight()
    {
        
    }
}
