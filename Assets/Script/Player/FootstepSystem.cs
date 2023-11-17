using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSystem : MonoBehaviour
{
    public AudioClip footstepSound;
    private AudioSource footstepAudio;
    public float maxFootstepDistance = 10f;

    void Start()
    {
        footstepAudio = GetComponent<AudioSource>();
        footstepAudio.maxDistance = maxFootstepDistance;
    }

    void Update()
    {
        // โค้ดอื่น ๆ เกี่ยวกับการเคลื่อนที่ของผู้เล่น

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            PlayFootstepSound();

            // แจ้งให้ศัตรูทราบ
            NotifyEnemies();
        }

        if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            StopFootstepSound();
        }
    }

    void PlayFootstepSound()
    {
        if (!footstepAudio.isPlaying)
        {
            //footstepAudio.PlayOneShot(footstepSound);
        }
    }

    void StopFootstepSound()
    {
        footstepAudio.Stop();
    }

    void NotifyEnemies()
    {
        // หาคอลไลเดอร์ทั้งหมดภายในระยะทาง maxFootstepDistance
        Collider[] colliders = Physics.OverlapSphere(transform.position, maxFootstepDistance);

        foreach (Collider collider in colliders)
        {
            // ตรวจสอบว่าคอลไลเดอร์เป็นของศัตรูหรือไม่
            AItest enemy = collider.GetComponent<AItest>();

            if (enemy != null)
            {
                // แจ้งให้ศัตรูทราบเรื่องเสียง

               // enemy.OnFootstepHeard(transform.position);
            }
        }
    }
}
