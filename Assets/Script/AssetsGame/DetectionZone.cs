using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    public string tagTarget = "Player";

    public List<Collider2D> deracredObjs = new List<Collider2D>();

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == tagTarget)
        {
            deracredObjs.Add(collider);
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == tagTarget)
        {
            deracredObjs.Remove(collider);
        }
    }

}
