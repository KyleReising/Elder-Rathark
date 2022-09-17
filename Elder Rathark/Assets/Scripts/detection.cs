using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detection : MonoBehaviour
{
    //[SerializeField] private LayerMask layermask;
    private Mesh mesh;
    private Vector3 origin = Vector3.zero;
    private float startingAngle;
    private float fov;
    private bool hittingPlayer = false;

    //helper function
    Vector3 GetVectorFromAngle(float angle) 
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad),Mathf.Sin(angleRad));
    }

    //helper function
    float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0)
            n += 360;
        return n;
    }

    private void Start()
    {
        mesh = new Mesh();
        fov = 90f;
        GetComponent<MeshFilter>().mesh = mesh;
    }

    private void LateUpdate()
    {
        hittingPlayer = false;
        int rayCount = 50;
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;
        float viewDistance = 5f;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycasthit2d = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance);//, layermask);
            if (raycasthit2d.collider == null)
            { vertex = origin + GetVectorFromAngle(angle) * viewDistance; }
            else
            { 
                vertex = raycasthit2d.point;
                if(raycasthit2d.rigidbody)
                {
                    hittingPlayer = true;
                }
            }
        

            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }
            vertexIndex++;
            angle -= angleIncrease;

        }

        mesh.vertices= vertices;
        mesh.uv= uv;
        mesh.triangles= triangles;
     }

    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }

    public void SetAimDirection(Vector3 aimDirection)
    {
        startingAngle = GetAngleFromVectorFloat(aimDirection) - fov / 2f;
    }

    public bool isHittingPlayer()
    { return hittingPlayer; }

}
