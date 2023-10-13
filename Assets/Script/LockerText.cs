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


    void Start()
    {

    }


    void Update()
    {
        float distance = Vector3.Distance(player.position, Locker.position);

        if (distance <= interactionDistance)
        {
            messageText.text = "[press \" R \" Hide]";
        }
        else
        {
            messageText.text = "";
        }
    }
}