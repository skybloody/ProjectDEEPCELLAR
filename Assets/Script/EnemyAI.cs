using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        agent.SetDestination(target.position);
    }

    private void DetectPlayerWalking()
    {
        float[] samples = new float[256];

        float sum = 0;
        foreach (float sample in samples)
        {
            sum += Mathf.Abs(sample);
        }

        float average = sum / samples.Length;
    }


}
