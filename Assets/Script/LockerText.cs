using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LockerText : MonoBehaviour
{
    public Vector3 offset;
    public Transform player;
    public Transform Locker;
    public TextMeshProUGUI messageText;

    public float interactionDistance = 2f;
    public float displayTime = 3f;

    private bool displayMessage = false;


    void Start()
    {

    }


    void Update()
    {
        float distance = Vector3.Distance(player.position, Locker.position);

        if (distance <= interactionDistance)
        {
            if (!displayMessage)
            {
                StartCoroutine(DisplayMessageForTime("[press \" R \" Hide]", displayTime));
                displayMessage = true;
            }
        }
        else
        {
            messageText.text = "";
            displayMessage = false;
        }
    }
    IEnumerator DisplayMessageForTime(string text, float time)
    {
        messageText.text = text;
        yield return new WaitForSeconds(time);
        messageText.text = "";
    }
}