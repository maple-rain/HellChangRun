using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class SideMapObject : MonoBehaviour
{
    private MeshFilter[] sideObject;
    private MeshFilter side;

    int randomindex;

    private void Awake()
    {
        side = GetComponent<MeshFilter>();
        sideObject = Resources.LoadAll<MeshFilter>("Buildings");
    }

    private void Start()
    {
        randomindex = Random.Range(0, sideObject.Length);
        side.sharedMesh = sideObject[randomindex].sharedMesh;
    }

    public void DeploymentObject(GameObject obj , bool isLeft)
    {
        
        if (isLeft)
        {
            obj.transform.position = new Vector3(-22, 0, 0);
            obj.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else
        {
            obj.transform.position = new Vector3(22, 0, 0);
            obj.transform.rotation = Quaternion.Euler(new Vector3(0, -180, 0));
        }
    }

    public void RerollSide(GameObject obj)
    {
        MeshFilter side = obj.GetComponent<MeshFilter>();
        randomindex = Random.Range(0, sideObject.Length);
        side.sharedMesh = sideObject[randomindex].sharedMesh;
    }
}
