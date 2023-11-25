using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Final : MonoBehaviour
{
    private bool hasKey = false;
    public GameObject key;
    public GameObject door;
    public float interactionRadius = 2f;
    public TextMeshProUGUI messageText;
    public GameWin GameWin;

    void Start()
    {
        UpdateMessageText();
    }

    void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, interactionRadius);
        bool isNearDoor = System.Array.Exists(colliders, collider => collider.gameObject == door);

        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject == key && !hasKey)
                {
                    CollectKey();
                }
                else if (collider.gameObject == door && hasKey)
                {
                    OpenDoor();
                }
            }
        }
        if (isNearDoor)
        {
            if (!hasKey)
            {
                messageText.text = "ต้องการคีย์การ์ด";
            }
            else
            {
                messageText.text = "[ E ] ขึ้นลิฟท์";
            }
        }
        else
        {
            messageText.text = "";
        }
    }

    void CollectKey()
    {
        hasKey = true;
        UpdateMessageText();
        Debug.Log("Key Collected!");
        key.SetActive(false);
    }

    void OpenDoor()
    {
        if (door != null)
        {
            UpdateMessageText();
            Debug.Log("Door Opened!");
            GameWin.isGameWin = true;
            gameObject.SetActive(false);
        }
    }

    void UpdateMessageText()
    {
        // Removed UpdateMessageText function since it was directly used in Update
    }
}
