﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : MonoBehaviour
{

    [SerializeField]
    float fov = 90f , 
    viewDistance = 50, 
    angle = 0f;
    
    [SerializeField]
    int rayCount = 50;
 
    void Start()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        Vector3 origin = Vector3.zero;
        float angleIncrease = fov / rayCount;
 

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i= 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit hit;
            if (Physics.Raycast(origin,GetVectorFromAngle(angle),out hit,viewDistance)){
                //hit object
                vertex = hit.point;
                Debug.Log("hit object");
            }
            else
            {
                //no hit
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;
                Debug.Log("no hit");
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

            angle -= angleIncrease; //counter clockwise
        }

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 GetVectorFromAngle(float angle)
    {
        //angle 0 -> 360
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }
}
