using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVMesh : MonoBehaviour
{
    FOV fov;
    Mesh mesh;
    RaycastHit2D hit;
    [SerializeField] float meshRes = 2;
    [HideInInspector] public Vector3[] vertices;
    [HideInInspector] public int[] triangles;
    [HideInInspector] public int stepCount;
    public Vector2 dir;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        fov = GetComponentInParent<FOV>();
    }
    void LateUpdate()
    {
        MakeMesh(); 
    }
    void MakeMesh()
    {
        stepCount = Mathf.RoundToInt(fov.viewAngle * meshRes);
        float stepAngle = fov.viewAngle / stepCount;

        List<Vector3> viewVertex = new List<Vector3>();

        hit = Physics2D.Raycast(transform.position, dir, fov.viewRadius, fov.obstacleMask);



        for (int i = 0; i <= stepCount; i++)
        { 
         float angle = fov.transform.eulerAngles.y - fov.viewAngle / 2 + stepCount * i;
         Vector3 dir = fov.DirFromAngle(angle, false);
         hit = Physics2D.Raycast(fov.transform.position, dir, fov.viewRadius, fov.obstacleMask);
            if ((hit.collider == null))
            {
                viewVertex.Add(transform.position + dir.normalized * fov.viewRadius);
            }
            else
            {
                viewVertex.Add(hit.point); 
            }

        }
        int vertexCount = viewVertex.Count + 1;

        vertices = new Vector3[vertexCount];
        triangles = new int[(vertexCount - 2) * 3];

        vertices[0] = Vector3.zero;

        for (int i = 0; i < vertexCount - 1; i++)
        {
            vertices[i + 1] = transform.InverseTransformPoint(viewVertex[i]);
            if (i < vertexCount - 2)
            { 
             
            }
        }
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

    }
}