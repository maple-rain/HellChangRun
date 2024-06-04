using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class SideMapObject : MonoBehaviour
{
    private GameObject[] sideObject;

    private void Start()
    {
        sideObject = Resources.LoadAll<GameObject>("Buildings");           
    }

    public GameObject LeftDeploymentObject()
    {
        int randomindex = Random.Range(0, sideObject.Length);
        GameObject obj = Instantiate(sideObject[randomindex]);
        obj.transform.position = new Vector3(-14, 0, 0);
        obj.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        return obj;
    }

    public GameObject RightDeploymentObject()
    {
        int randomindex = Random.Range(0, sideObject.Length);
        GameObject obj = Instantiate(sideObject[randomindex]);
        obj.transform.position = new Vector3(14, 0, 0);
        obj.transform.rotation = Quaternion.Euler(new Vector3(0, -180, 0));
        return obj;
    }
}
