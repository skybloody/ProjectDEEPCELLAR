using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ItemEffect : MonoBehaviour
{
    public Light2D Lighteffect;


    void Start()
    {
      Lighteffect.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Test"))
        {
            Lighteffect.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Test"))
        {
            Lighteffect.enabled = false;
        }
    }
}
