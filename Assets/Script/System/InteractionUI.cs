using UnityEngine;
using TMPro;

public class InteractionUI : MonoBehaviour
{
    public TMP_Text InteractionText;

    public void Show(string message)
    {
        InteractionText.enabled = true;
        InteractionText.text = message;
    }
    public void Hide()
    {
        InteractionText.enabled = false;
    }
}
