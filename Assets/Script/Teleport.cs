using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform portal;
    private GameObject player;
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag ("Player"))
        {
            if(Vector2.Distance(player.transform.position, transform.position) > 0.3f)
            {
                StartCoroutine(PortalIn());
            }
        }
    }
    IEnumerator PortalIn()
    {
        yield return new WaitForSeconds(0.5f);
        player.transform.position = portal.position;
        yield return new WaitForSeconds(0.5f);
    }
}
