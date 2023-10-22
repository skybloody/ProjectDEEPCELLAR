using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    private bool isMouseVisible = true;

    private void Start()
    {
        Cursor.visible = isMouseVisible;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // สามารถเปลี่ยนเงื่อนไขตรงนี้ตามที่คุณต้องการ
        {
            isMouseVisible = !isMouseVisible;
            Cursor.visible = isMouseVisible;
        }
    }
}