using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMouseCursor : MonoBehaviour
{
    private bool isCursorHidden = false;

    void Start()
    {
        
        Cursor.visible = false;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.G))
        {
            isCursorHidden = !isCursorHidden;
            Cursor.visible = isCursorHidden;
        }
    }
}
