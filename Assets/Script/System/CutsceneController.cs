using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(NextScene());
    }
    IEnumerator NextScene()
    { 
     yield return new WaitForSeconds(8.3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
