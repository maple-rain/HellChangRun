using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private UIManager uiManager;
    
    [SerializeField]
    private AudioManager audioManager;

    [SerializeField]
    private CharacterManager characterManager;

    [SerializeField]
    private MapManager mapManager;

    [SerializeField]
    private ItemManager itemManager;

    [SerializeField]
    private MiniGameManager miniGameManager;

    private void Awake()
    {
        base.Awake();
    }
    
}


