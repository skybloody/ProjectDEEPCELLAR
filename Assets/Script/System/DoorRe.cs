using UnityEngine;
using TMPro;

public class DoorRe : MonoBehaviour
{
    private bool hasKey = false;
    public GameObject key;
    public GameObject door;
    public GameObject hiddenObject; // Reference to the GameObject to be hidden/shown
    public float interactionRadius = 2f;
    public TextMeshProUGUI messageText;

    void Start()
    {
        UpdateMessageText();
        hiddenObject.SetActive(false);
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
                messageText.text = "ต้องการกรรไกร";
            }
            else
            {
                messageText.text = "[ E ] ตัดเถาวัลย์ทิ้ง";
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
            door.SetActive(false);

            if (hiddenObject != null)
            {
                hiddenObject.SetActive(true); // Show the hidden object
            }
        }
    }

    void UpdateMessageText()
    {
        // Removed UpdateMessageText function since it was directly used in Update
    }
}