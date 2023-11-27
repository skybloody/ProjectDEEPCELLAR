using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    private bool cutsceneStarted = false;
    public PlayableDirector playableDirector;



    void Update()
    {
        
        if (!cutsceneStarted)
        {
            
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                cutsceneStarted = true;
                StartCoroutine(NextScene());
            }
        }
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(8.3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
