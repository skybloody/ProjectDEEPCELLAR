using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{
    [SerializeField] private Light2D Light;

    private int frames = 0;

    [SerializeField] private int framesPerRandomize;

    [SerializeField] private float minValue;
    [SerializeField] private float maxValue;

    void Start()
    {

    }

    void Update()
    {
        frames++;
        if (frames % framesPerRandomize == 0)
        {
            RandomizeIntensity();
        }
    }

    void RandomizeIntensity()
    {
        // Create an instance of the Random class
        System.Random random = new System.Random();


        float randomValue = (float)(random.NextDouble() * (maxValue - minValue) + minValue);

        Light.intensity = randomValue;
    }
}