using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutOutObject : MonoBehaviour
{
    [SerializeField]
    private Transform targetObject;

    [SerializeField]
    private LayerMask wallMask;

    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 cutoutPos = mainCamera.WorldToViewportPoint(targetObject.position);
        cutoutPos.y /= (Screen.width / Screen.height);

        Vector2 offset = targetObject.position - transform.position;
        RaycastHit2D[] hitObject = Physics2D.RaycastAll(transform.position, offset, offset.magnitude, wallMask);

        for (int i = 0; i < hitObject.Length; ++i)
        {
            Material[] materials = hitObject[i].transform.GetComponent<SpriteRenderer>().materials;

            for(int m = 0; m < materials.Length; ++m)
            {
                materials[m].SetVector("_CutoutPos", cutoutPos);
                materials[m].SetFloat("_CutoutSize", 0.1f);
                materials[m].SetFloat("_FalloffSize", 0.05f);
            }
        }
    }
    
}
