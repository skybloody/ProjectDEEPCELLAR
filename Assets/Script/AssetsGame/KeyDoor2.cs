using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Key can be collected. Press 'E' to collect.");

            // ส่ง GameObject ของ key ไปยัง PlayerController เพื่อให้ player รู้ว่ามี key อยู่
            PlayerMovement playerController = other.GetComponent<PlayerMovement>();
            if (playerController != null)
            {
             //   playerController.SetKey(this.gameObject);
            }
        }
    }
    public void CollectKey()
    {
        Debug.Log("Key collected!");
        gameObject.SetActive(false); // หรือทำการทำลาย GameObject ของ key
    }

    private void UnlockDoors()
    {
        // หา GameObject ทั้งหมดที่มี Tag "Door"
        GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");

        // เรียก UnlockDoor ของทุกประตู
        foreach (GameObject door in doors)
        {
            DoorController doorController = door.GetComponent<DoorController>();
            if (doorController != null)
            {
             //   doorController.UnlockDoor();
            }
        }
    }
}
