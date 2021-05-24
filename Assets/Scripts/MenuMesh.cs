using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MenuMesh : MonoBehaviour
{
    public Mesh mesh;

    public Vector3[] vertices;
    public int[] triangles;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();
    }

    void CreateShape()
    {
        //making a simple square

        vertices = new Vector3[]
        {
            //starts at bottom left corner
            new Vector3 (-300,-100,0),
            new Vector3 (-300,300,0),
            new Vector3 (300,-100,0),
            new Vector3 (300,300,0)
        };

        triangles = new int[]
        {
            0, 1, 2,
            1, 3, 2
        };


    }

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }
}
