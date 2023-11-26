using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    private bool cutsceneStarted = false;

    void Update()
    {
        // ตรวจสอบว่า Cutscene ยังไม่เริ่ม
        if (!cutsceneStarted)
        {
            // ตรวจสอบเงื่อนไขที่ต้องการเพื่อเริ่ม Cutscene (เช่น การกดปุ่ม)
            if (Input.GetKeyDown(KeyCode.Space)) // ตัวอย่าง: กดปุ่ม Space เพื่อเริ่ม Cutscene
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
