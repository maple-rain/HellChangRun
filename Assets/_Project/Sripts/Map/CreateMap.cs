using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    [SerializeField]
    private GameObject mapParts;


    private Queue<GameObject> mapPartsList = new Queue<GameObject>();
    private Queue<GameObject> mapObjectPartsList = new Queue<GameObject>();

    public int mapPartsCount;
    public int sideObjectCount;

    public Transform playerTransform;

    private GameObject playerDistanceCheck;

    private SideMapObject sideMapObject;

    private void Awake()
    {
        for (int i = 0; i < mapPartsCount; i++)
        {
            GameObject obj = Instantiate(mapParts);
            obj.transform.parent = transform;
            mapPartsList.Enqueue(obj);
            obj.SetActive(false);
        }

        for (int i = 0; i < sideObjectCount; i++)
        {
            GameObject obj = new GameObject() ;
            obj.transform.parent = transform;
            mapObjectPartsList.Enqueue(obj);
            obj.SetActive(false);
        }
    }

    private void Start()
    {
        sideMapObject = GameManager.Instance.mapManager.sideMapObject;
        GameObject map = mapPartsList.Dequeue();
        map.SetActive(true);
        mapPartsList.Enqueue(map);
        StartCoroutine(RespawnMap());
    }

    IEnumerator RespawnMap()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);

            for (int i = -1; i < 2; i++)
            {
                GameObject map = mapPartsList.Dequeue();
                setPosition(map, i);
                GameObject sideLeft = mapObjectPartsList.Dequeue();
                sideLeft=sideMapObject.LeftDeploymentObject();
                sideLeft.transform.parent = transform;
                setPosition(sideLeft, i);
                sideLeft.SetActive(true);
                GameObject sideRight = mapObjectPartsList.Dequeue();
                sideRight = sideMapObject.RightDeploymentObject();
                sideRight.transform.parent = transform;
                setPosition(sideRight , i);
                sideRight.SetActive(true);
                map.SetActive(true);
                mapPartsList.Enqueue(map);
                mapObjectPartsList.Enqueue(sideLeft);
                mapObjectPartsList.Enqueue(sideRight);
            }
        }
    }


    private void setPosition(GameObject obj , int i)
    {
        Vector3 newPosition = new Vector3(obj.transform.position.x ,0,playerTransform.transform.position.z);
        newPosition.z += 21 * i; 
        obj.transform.position = newPosition;
    }   
}
