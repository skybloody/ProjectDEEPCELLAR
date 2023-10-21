using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightControl : MonoBehaviour
{
    [SerializeField] GameObject flashlight;
    private bool candleAActive = false;
    public Transform player; // กำหนดผู้เล่นในเอดิเทอร์
    private Vector3 initialPlayerPosition;

    void Start()
    {
        flashlight.gameObject.SetActive(false);
        initialPlayerPosition = player.position;
    }

    void Update()
    {
        Vector3 offset = player.position - initialPlayerPosition;

        // ปรับค่า Transform ของวัตถุตามผู้เล่น และเพิ่มตำแหน่งเริ่มต้น
        transform.position = transform.position + offset;

        // อัปเดตตำแหน่งเริ่มต้นให้เป็นตำแหน่งปัจจุบันของผู้เล่น
        initialPlayerPosition = player.position;

        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleCandle();
        }
    }

    void ToggleCandle()
    {
        candleAActive = !candleAActive;
        flashlight.gameObject.SetActive(candleAActive);
    }

}

