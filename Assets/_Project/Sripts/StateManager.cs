using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    [SerializeField]
    private CharacterManager characterManager;

    [SerializeField]
    private MapManager mapManager;

    [SerializeField]
    private MapObjectManager mapObjectManager;

    [SerializeField]
    private ItemManager itemManager;

    [SerializeField]
    private MiniGameManager miniGameManager;

    private GameState currentState;

    public void ChangeState(GameState newState)
    {
        currentState = newState;
        switch (newState)
        {
            case GameState.GameStarted:
                //게임 시작 시
                
                break;
            case GameState.MainScene:
                //메인화면 씬 로드
                //SceneManager.LoadScene("MainScene");
                break;
            case GameState.PlayScene:
                //플레이 씬 
                break;
        }
    }
 
    //public void ChangeScene()
    //{
    //    ChangeState(GameState.MainScene);
    //}
    

}