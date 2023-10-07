using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class EnemyLineOfSighChecker : MonoBehaviour
{
    public SphereCollider Collider;
    public float FieldOfView = 90f;
    public LayerMask LineOfSightLayers;

    public delegate void GainSightEvent(Transform Target);
    public GainSightEvent OnGainSight;
    public delegate void LoseSightEvent(Transform Target);
    public GainSightEvent OnLoseSight;

    private Coroutine CheckForLineOfSightCoroutine;

    private void Awake()
    {
        Collider = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (!CheckForLineOfSight(other.transform))
        {
            //CheckForLineOfSightCoroutine = StartCoroutine(CheckForLineOfSight(other.transform));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        OnLoseSight?.Invoke(other.transform);
        {
            StopCoroutine(CheckForLineOfSightCoroutine);
        }
    }

    private bool CheckLineSight(Transform Target)
    {
        Vector3 direction = (Target.transform.position - transform.position).normalized;
        float dotProduct = Vector3.Dot(transform.forward, direction);
        if (dotProduct >= Mathf.Cos(FieldOfView))
        {
            if (Physics.Raycast(transform.position, direction, out RaycastHit hit, Collider.radius, LineOfSightLayers))
            {
                OnGainSight?.Invoke(Target);
                return true;
            }
        }
        return false;
    }

    private IEnumerator CheckForLineSight(Transform target)
    {
        WaitForSeconds Wait = new WaitForSeconds(0.5f);

        //while(CheckForLineOfSight(Target))
        {
            yield return Wait;
        }
    }
}
