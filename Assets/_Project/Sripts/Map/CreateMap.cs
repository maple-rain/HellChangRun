using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CreateMap : MonoBehaviour
{
    [SerializeField]
    private GameObject mapParts;
    [SerializeField]
    private GameObject sideParts;

    private Queue<GameObject> mapPartsList = new Queue<GameObject>();
    private Queue<GameObject> sideMapPartsList = new Queue<GameObject>();

    public int mapPartsCount;
    public int sideObjectCount;

    public Transform playerTransform;

    private SideMapObject sideMapObject;
    private MapObject mapObject;



    private void Awake()
    {
        for (int i = 0; i < mapPartsCount; i++)
        {
            GameObject obj = Instantiate(mapParts);
            obj.transform.parent = transform;
            mapPartsList.Enqueue(obj);
            obj.SetActive(false);
        }

        for(int i = 0;i < sideObjectCount; i++)
        {
            GameObject obj = Instantiate(sideParts);
            obj.transform.parent = transform;
            sideMapPartsList.Enqueue(obj);
            obj.SetActive(false);
        }

    }

    private void Start()
    {
        sideMapObject = GameManager.Instance.mapManager.sideMapObject;
        mapObject = GameManager.Instance.mapManager.mapObject;
        StartCoroutine(RespawnMap());
        StartCoroutine(SpawnSide());
        StartCoroutine(SpawnFood());
        StartCoroutine(SpawnObstecle());
    }

    IEnumerator RespawnMap()
    {
        while (true)
        {
            for (int i = -1; i < 10; i++)
            {
                GameObject map = mapPartsList.Dequeue();
                setPosition(map, i);
                map.SetActive(true);
                mapPartsList.Enqueue(map);      
            }
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator SpawnSide()
    {
        int j = 0;
        while (true)
        {                  
            GameObject side = sideMapPartsList.Dequeue();
            side.SetActive(true);
            for (int i = 0; i < side.transform.childCount; i++)
            {   
                GameObject obj = side.transform.GetChild(i).gameObject;
                
                if (i % 2 == 0)
                {
                    sideMapObject.DeploymentObject(obj,true);
                    sideMapObject.RerollSide(obj);
                    setSidePosition(obj, (i) + j);
                }
                else
                {
                    sideMapObject.DeploymentObject(obj, false);
                    sideMapObject.RerollSide(obj);
                    setSidePosition(obj, (i-1) + j);
                }
            }
            sideMapPartsList.Enqueue(side);
            j = 5;
            yield return new WaitForSeconds(7f);
        }
    }

    IEnumerator SpawnFood()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            int randomY = Random.Range(1, 8);
            Vector3[] randomRoad =
            {
                new Vector3(-8f,randomY,playerTransform.position.z + 20f),
                new Vector3(0f,randomY,playerTransform.position.z + 20f),
                new Vector3(8f,randomY,playerTransform.position.z + 20f)
            };
            int randomSapwn = Random.Range(0,randomRoad.Length);

            mapObject.SpanwFood(randomRoad[randomSapwn]);
            
        }
    }

    IEnumerator SpawnObstecle()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            Vector3[] randomRoad =
            {
                new Vector3(-8f,0f,playerTransform.position.z + 20f),
                new Vector3(0f,0f,playerTransform.position.z + 20f),
                new Vector3(8f,0f,playerTransform.position.z + 20f)
            };
            int randomSapwn = Random.Range(0, randomRoad.Length);
            mapObject.SpanwObstecle(randomRoad[randomSapwn]);

        }
    }


    private void setPosition(GameObject obj , float i)
    {
        Vector3 newPosition = new Vector3(obj.transform.position.x ,0,playerTransform.position.z);
        newPosition.z += 21 * i; 
        obj.transform.position = newPosition;
    }   

    private void setSidePosition(GameObject obj, float i)
    {
        Vector3 newPosition = new Vector3(obj.transform.position.x, 0, playerTransform.position.z + 20);
        newPosition.z += 21 * i;
        obj.transform.position = newPosition;
    }
}
