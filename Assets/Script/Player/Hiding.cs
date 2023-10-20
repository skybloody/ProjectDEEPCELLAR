using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding : MonoBehaviour
{
    
    public SpriteRenderer sr;
    public bool PlayerHide = false;

    public int hiddenPlayerLayer;
    public LayerMask wallLayer;
    private int PlayerLayer;

    void Start()
    {
        sr = GetComponent <SpriteRenderer>();
       // hiddenPlayerLayer = LayerMask.NameToLayer("Hidden");
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
           // ToggleHide();
            ToggleHiding();
        }
    }
    void ToggleHide()
    {
        PlayerHide = !PlayerHide;

        if (PlayerHide)
        {
            Physics2D.IgnoreLayerCollision(gameObject.layer, wallLayer, true);
            gameObject.layer = hiddenPlayerLayer; // ตั้ง Layer เมื่อซ่อน
        }
        else
        {
            Physics2D.IgnoreLayerCollision(gameObject.layer, wallLayer, false);
            gameObject.layer = PlayerLayer; // ตั้งคืนเป็น Layer ปกติของ Player
        }
    }
     void ToggleHiding()
    {
        PlayerHide = !PlayerHide;

        if (PlayerHide){
            Physics2D.IgnoreLayerCollision(6, 9, true);
            sr.sortingOrder = 0;
            
        }
        else{
            Physics2D.IgnoreLayerCollision(6, 9, false);
            sr.sortingOrder = 2;
            
        }
    }
}

