using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StaminaBar : MonoBehaviour
{
    public Slider staminaBar;
    private int maxStamina = 250;
    public int currentStamina;
    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;
    public static StaminaBar instance;

    public Vector3 offset;
    public Transform player;
    float currentVelocity = 0;

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
        float maxStamina = Mathf.SmoothDamp(staminaBar.value, staminaBar.maxValue, ref currentVelocity, 100 * Time.deltaTime);
        staminaBar.gameObject.SetActive(true);
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
           
        }
    }

    public IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);

        while (currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 50;
            staminaBar.value = currentStamina;


            staminaBar.gameObject.SetActive(currentStamina < maxStamina);
            yield return regenTick;
        }
        regen = null;
    }
}
