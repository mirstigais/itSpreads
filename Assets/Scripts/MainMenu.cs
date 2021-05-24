using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
public class MainMenu : MonoBehaviour
{
    Mesh backgroundMesh;
    List<Vector3> oldVertices;
    List <int> triangles;
    private void Start()
    {
        oldVertices = new List<Vector3>();
        triangles = new List<int>();
        backgroundMesh = GetComponentInChildren<MenuMesh>().mesh;
        //Arrays store references not values
        CopyToList(backgroundMesh.vertices,oldVertices);
        CopyToList(GetComponentInChildren<MenuMesh>().triangles, triangles);
    }

    void CopyToList(Vector3[] arr, List<Vector3> verticesList)
    {
        Debug.Log(arr.Length);
        for (int i = 0; i < arr.Length; i++)
        {
            verticesList.Add(arr[i]);
        }
        Debug.Log(verticesList.Count);
    }

    void CopyToList(int[] arr, List<int> verticesList)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            verticesList.Add(arr[i]);
        }
        Debug.Log(verticesList.Count);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void MouseOverPlay()
    {
        StartCoroutine("ModifyMesh",0);
    }

    public void MouseOverQuit()
    {
        StartCoroutine("ModifyMesh", 1);
    }

    IEnumerator ModifyMesh(int button)
    {
        //backgroundMesh.Clear();

        //this sohuld reset vertices to their original positions
        List<Vector3> newVertices = new List<Vector3> (oldVertices);
        switch (button)
        {
            default:
                newVertices[1] = new Vector3(0, 300, 0);
                newVertices[3] = new Vector3(0, 300, 0);
                break;
            case 1:
                newVertices[0] = new Vector3(0, -200, 0);
                newVertices[2] = new Vector3(0, -200, 0);
                break;
        }

        backgroundMesh.SetVertices(newVertices);
            backgroundMesh.triangles = triangles.ToArray();
            backgroundMesh.RecalculateBounds();
            backgroundMesh.RecalculateNormals();

        Debug.Log(newVertices[0]);
        Debug.Log(newVertices[1]);
        Debug.Log(newVertices[2]);
        Debug.Log(newVertices[3]);
        yield return null;
    }
}
