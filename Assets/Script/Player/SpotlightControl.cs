using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightControl : MonoBehaviour
{
    [SerializeField] GameObject flashlight;
    private bool candleAActive = false;
    

    void Start()
    {
        flashlight.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleCandle();
        }
    }

    void ToggleCandle()
    {
        candleAActive = !candleAActive;
        flashlight.gameObject.SetActive(candleAActive);
    }

}

