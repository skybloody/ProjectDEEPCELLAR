using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objective : MonoBehaviour
{
    public AudioSource objSFX;
    public GameObject theObjective;
    public GameObject theTrigger;
    public GameObject theText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(missionObj());
        }
    }

    private IEnumerator missionObj()
    {
        objSFX.Play();
        theObjective.SetActive(true);
        theObjective.GetComponent<Animator>().Play("ObjectiveAnimation");
        theText.GetComponent<Text>().text = "หิวข้าว";
        yield return new WaitForSeconds(5.3f);
        theText.GetComponent<Text>().text = "";
        theTrigger.SetActive(false);
        theObjective.SetActive(false);
    }
}
