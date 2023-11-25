using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextTrigger : MonoBehaviour
{
    public GameObject TextUI;
    public GameObject Trigger;

    // Start is called before the first frame update
    void Start()
    {
        TextUI.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            TextUI.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        TextUI.SetActive(false);
    }

}
