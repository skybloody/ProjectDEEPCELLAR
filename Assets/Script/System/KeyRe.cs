using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyRe : MonoBehaviour
{
    private bool hasKey = false;
    public GameObject key;
    public GameObject door;
    public float interactionRadius = 2f; // รัศมีที่ผู้เล่นต้องอยู่ในเพื่อทำการเก็บคีย์หรือเปิดประตู
    public TextMeshProUGUI messageText; // Reference ไปยัง UI Text

    void Start()
    {   
        UpdateMessageText(); // เริ่มต้นให้แสดงข้อความตามสถานะปัจจุบัน
    }

    void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, interactionRadius);
        bool isNearDoor = System.Array.Exists(colliders, collider => collider.gameObject == door);

        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject == key && !hasKey)
                {
                    CollectKey();
                }
                else if (collider.gameObject == door && hasKey)
                {
                    OpenDoor();
                }
            }
            
        }
        if (isNearDoor)
        {
            if (!hasKey)
            {
                messageText.text = "ต้องการคีมตัดโซ่";
            }
            else
            {
                messageText.text = "[ E ] ตัดโซ่";
            }
        }
        else
        {
            messageText.text = "";
        }
    }

    void CollectKey()
    {
        hasKey = true;
        UpdateMessageText(); // อัพเดทข้อความ
        Debug.Log("Key Collected!");
        key.SetActive(false); // ซ่อน Key โดยการปิด GameObject ของ Key
    }

    void OpenDoor()
    {
        if (door != null)
        {
            UpdateMessageText(); // อัพเดทข้อความ
            // กระทำที่ต้องการเมื่อประตูถูกเปิด
            Debug.Log("Door Opened!");
            door.SetActive(false); // หรือใช้ SetActive(true) เพื่อเปิด GameObject ของประตู
        }
    }
    void UpdateMessageText()
    {
       
    }
}
