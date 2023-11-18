using UnityEngine;

public class Door_1 : Interactable
{
    public GameObject target;
    public override void Interact()
    {
        SceneControl.TransitionPlayer(target.transform.position);
    }
}
