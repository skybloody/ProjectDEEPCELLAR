using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeWalls : MonoBehaviour
{
    public float maxAlpha = 1.0f; // Maximum alpha value (fully opaque)
    public float minAlpha = 0.2f; // Minimum alpha value (semi-transparent)

    private Material wallFade;
    private bool playerInside;

    private void Start()
    {
        // Get the material of the roof object
        wallFade = GetComponent<Renderer>().material;
        // Initialize alpha to the maximum value
        SetAlpha(maxAlpha);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Player entered the trigger zone, lower the texture alpha
            SetAlpha(minAlpha);
            playerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Player exited the trigger zone, raise the texture alpha
            SetAlpha(maxAlpha);
            playerInside = false;
        }
    }

    private void SetAlpha(float alphaValue)
    {
        Color color = wallFade.color;
        color.a = alphaValue;
        wallFade.color = color;
    }
}

