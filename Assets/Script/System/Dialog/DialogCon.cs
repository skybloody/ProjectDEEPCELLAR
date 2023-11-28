using System.Collections;
using UnityEngine;
using TMPro;
using System;

public class DialogCon : MonoBehaviour
{
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private TMP_Text textlabel;
    [SerializeField] private DialogOBJ testDialog;

    

    private DialogEffect diaeffect;
   


    private void Start()
    {
        diaeffect = GetComponent<DialogEffect>();
        CloseDialogueBox();
        ShowDialogue(testDialog);
    }
    public void ShowDialogue(DialogOBJ dialogOBJ)
    {
        dialogBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogOBJ));
        
    }
    private IEnumerator StepThroughDialogue(DialogOBJ dialogOBJ)
    {
        foreach (string dialogue in dialogOBJ.Dialogue)
        {
            yield return diaeffect.Run(dialogue, textlabel);
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        }
        CloseDialogueBox();
    }

    private void CloseDialogueBox()
    {
        dialogBox.SetActive(false);
        textlabel.text = string.Empty;
    }
}
