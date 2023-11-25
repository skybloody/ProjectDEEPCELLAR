using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : DetectionZone
{
    public string DoorOpenAnimatorParamName = "DoorOpen";

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (deracredObjs.Count > 0)
        {
            animator.SetBool(DoorOpenAnimatorParamName, true);
        }
        else
        { 
         animator.SetBool (DoorOpenAnimatorParamName, false);
        }
    }
}
