using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.BoolParameter;


public class LockerText : MonoBehaviour
{
    public Vector3 offset;
    public Transform player;
    public TextMeshProUGUI messageText;
    public Transform[] lockers;

    private bool[] displayMessages;
    public float interactionDistance = 2.0f;
    public float displayTime = 2.0f;
    private Coroutine[] messageCoroutines;

    private void Awake()
    {
        displayMessages = new bool[lockers.Length];
        messageCoroutines = new Coroutine[lockers.Length];
    }

    void Update()
    {
        for (int i = 0; i < lockers.Length; i++)
        {
            float distance = Vector3.Distance(player.position, lockers[i].position);

            if (distance <= interactionDistance)
            {
                if (!displayMessages[i])
                {
                    if (messageCoroutines[i] != null)
                    {
                        StopCoroutine(messageCoroutines[i]);
                    }

                    messageCoroutines[i] = StartCoroutine(DisplayMessageForTime("[press \" T \" Hide]", displayTime, i));
                    displayMessages[i] = true;
                }
            }
            else
            {
                if (displayMessages[i])
                {
                    StopCoroutine(messageCoroutines[i]);
                    messageText.SetText("");
                    displayMessages[i] = false;
                }
            }
        }
    }

    IEnumerator DisplayMessageForTime(string text, float time, int index)
    {
        messageText.SetText(text);
        yield return new WaitForSeconds(time);
        messageText.SetText("");
        displayMessages[index] = false;
    }
}
