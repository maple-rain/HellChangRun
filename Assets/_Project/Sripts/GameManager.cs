using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.XR;

public enum GameState
{
    GameStarted,
    MainScene, //메인화면
    PlayScene,
    MinigameStart,
    MiniGameEnd,
    ShopScene,
    GameOver
}


public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private StateManager stateManager;

    [SerializeField]
    private UIManager uiManager;
    
    [SerializeField]
    private AudioManager audioManager;

    private void Awake()
    {
        base.Awake();
        stateManager.ChangeState(GameState.GameStarted);
    }

}


