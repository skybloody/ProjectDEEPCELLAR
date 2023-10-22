using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColl : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            GameOver.isGameOver = true;
            gameObject.SetActive(false);
        }
    }
}
