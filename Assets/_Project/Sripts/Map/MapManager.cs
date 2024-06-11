using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public CreateMap createMap;
    public MapObject mapObject;
    public SideMapObject sideMapObject;

    private void Awake()
    {
        GameManager.Instance.mapManager = this;
        createMap = GetComponent<CreateMap>();
        mapObject = GetComponent<MapObject>();
        sideMapObject = GetComponent<SideMapObject>();
    }
}