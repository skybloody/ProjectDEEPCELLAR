using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    void StartCutscene()
    {
        // ทำ cutscene ที่นี่

        // เมื่อ cutscene จบ
        SceneManager.LoadScene("NextScene");
    }
    void EndCutscene()
    {
        // เมื่อ cutscene จบ
        SceneManager.LoadScene("NextScene");
    }
}
