using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private StateManager stateManager;

    [SerializeField]
    private CharacterManager characterManager;

    [SerializeField]
    private MapManager mapManager;

    [SerializeField]
    private MapObjectManager mapObjectManager;

    [SerializeField]
    private UIManager uiManager;
    [SerializeField]
    private ItemManager itemManager;

    [SerializeField]
    private MiniGameManager miniGameManager;

    [SerializeField]
    private AudioManager audioManager;
    
}


