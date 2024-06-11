using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{  
    
    [SerializeField]
    private AudioManager audioManager;

    [SerializeField]
    private CharacterManager characterManager;

    public MapManager mapManager;

    [SerializeField]
    private ItemManager itemManager;

    protected override void Awake()
    {
        base.Awake();
    }
 
}


