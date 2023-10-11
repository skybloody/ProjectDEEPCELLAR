using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightControl : MonoBehaviour
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
            ToggleCandle();
        }
    }

    void ToggleCandle()
    {
        candleAActive = !candleAActive;
        candleA.gameObject.SetActive(candleAActive);
    }
}

