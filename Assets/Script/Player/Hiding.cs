using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding : MonoBehaviour
{
    
    public SpriteRenderer sr;
    public bool PlayerHide = false;
    

    

    void Start()
    {
        sr = GetComponent <SpriteRenderer>();
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ToggleHide();

        }
      
    }

   public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Locker"))
        {
            ToggleHide();
        }
    }

    void ToggleHide()
    {
        PlayerHide = !PlayerHide;

        if (PlayerHide){
            Physics2D.IgnoreLayerCollision(6, 7, true);
            sr.sortingOrder = 0;
            
        }
        else{
            Physics2D.IgnoreLayerCollision(6, 7, false);
            sr.sortingOrder = 2;
            
        }
    }
}

