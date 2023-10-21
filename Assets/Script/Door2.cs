using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2 : MonoBehaviour
{
    public GameObject door;
    public Animator animator;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("key picked up");

            door.GetComponent<BoxCollider2D>().enabled = false;

            this.gameObject.SetActive(false);

            if (collision.CompareTag("Player"))
            {
                animator.SetBool("IsOpenSide", true);
            }
        }
    }
}
