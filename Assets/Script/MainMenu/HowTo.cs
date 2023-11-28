using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowTo : MonoBehaviour
{
    public Canvas UIHowTo;
    public GameObject Trigger;


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UIHowTo.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // If the object exits the trigger zone, you might want to disable the Canvas
        if (other.CompareTag("Player"))
        {
            UIHowTo.enabled = false;
        }
    }
    public void OnBackButtonClick()
    {
        UIHowTo.enabled = false;
        Trigger.SetActive(false);
    }
}