using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class EnemyMovement : MonoBehaviour
{
    public LayerMask HidableLayers;
    public EnemyLineOfSighChecker LineOfSighChecker;
    public NavMeshAgent Agent;
    [Range(-1, 1)]
    [Tooltip("Lower is a better hiding spot")]
    public float HideSensitivity = 0;

    private Coroutine MovementCoroutine;
    private Collider[] Colliders = new Collider[10];

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();

        LineOfSighChecker.OnGainSight += HandleGainSight;
        LineOfSighChecker.OnLoseSight += HandleLoseSight;
    }

    private void HandleGainSight(Transform Target)
    {
        if (MovementCoroutine != null)
        {
            StopCoroutine(MovementCoroutine);
        }
        MovementCoroutine = StartCoroutine(Hide(Target));
    }

    private void HandleLoseSight(Transform Target)
    {
        if (MovementCoroutine != null)
        {
            StopCoroutine(MovementCoroutine);
        }
    }

    private IEnumerator Hide(Transform Target)
    {
        while (true)
        {
            int hits = Physics.OverlapSphereNonAlloc(Agent.transform.position, LineOfSighChecker.Collider.radius, Colliders, HidableLayers);
            for (int i = 0; i < hits; i++)
            {
                if (NavMesh.SamplePosition(Colliders[i].transform.position, out NavMeshHit hit, 2f, Agent.areaMask))
                {
                    if (!NavMesh.FindClosestEdge(hit.position, out hit, Agent.areaMask))
                    {
                        Debug.LogError($"Unble to find edge close to {hit.position}");
                    }
                    if (Vector3.Dot(hit.normal, (Target.position - hit.position).normalized) < HideSensitivity)
                    {
                        Agent.SetDestination(hit.position);
                        break;
                    }
                    else
                    {
                        if (NavMesh.SamplePosition(Colliders[i].transform.position - (Target.position).normalized * 2, out NavMeshHit hit2, 2f, Agent.areaMask))
                        {
                            if (!NavMesh.FindClosestEdge(hit2.position, out hit, Agent.areaMask))
                            {
                                Debug.LogError("$Unble to find edge close to {hit2.position} (second attempt)");
                            }

                            if (Vector3.Dot(hit2.normal, (Target.position - hit2.position).normalized) < HideSensitivity)
                            {
                                Agent.SetDestination(hit2.position);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    Debug.LogError("$Unblet to find NavMesh near object {Colliders[i].name} at {Colliders[i].transform.position}");
                }
            }
            yield return null;
        }
    }
}