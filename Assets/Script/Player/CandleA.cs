using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLight2D : MonoBehaviour
{
    [SerializeField] GameObject candleA;
    private bool candleAActive = false;

    void Start()
    {
        candleA.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (candleAActive == false)
            {
                candleA.gameObject.SetActive(true);
                candleAActive = true;
            }
            else
            {
                candleA.gameObject.SetActive(false);
                candleAActive = false;
            }
        }
    }

}




