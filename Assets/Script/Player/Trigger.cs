using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject prefabWithSpriteRenderer;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = prefabWithSpriteRenderer.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Color newColor = spriteRenderer.color;
            newColor.a = 0.5f;
            spriteRenderer.color = newColor;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Color newColor = spriteRenderer.color;
            newColor.a = 1f;
            spriteRenderer.color = newColor;
        }
    }
}
