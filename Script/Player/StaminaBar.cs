using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StaminaBar : MonoBehaviour
{
    public Slider staminaBar;
    private int maxStamina = 250;
    public int currentStamina;
    private WaitForSeconds regenTick = new WaitForSeconds(0.3f);
    private Coroutine regen;
    public static StaminaBar instance;

    public Vector3 offset;
    public Transform player;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        staminaBar.gameObject.SetActive(false);
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }
    private void Update()
    {
        if (player != null)
        {
            Vector3 playerScreenPos = Camera.main.WorldToScreenPoint(player.position + offset);
            staminaBar.transform.position = playerScreenPos;
            staminaBar.gameObject.SetActive(true);
        }
        else
        {
            staminaBar.gameObject.SetActive(false);
        }
    }


    public void UseStamina(int amount)
    {
        if (currentStamina - amount >= 0)
        {
            currentStamina -= amount;
            staminaBar.value = currentStamina;

            
            staminaBar.gameObject.SetActive(true);

            if (regen != null)
                StopCoroutine(regen);

            regen = StartCoroutine(RegenStamina());
        }
        else
        {
            Debug.Log("Not enough stamina");
        }
    }

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);

        while (currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 8;
            staminaBar.value = currentStamina;


            staminaBar.gameObject.SetActive(currentStamina < maxStamina);
            yield return regenTick;
        }
        regen = null;
    }
}
