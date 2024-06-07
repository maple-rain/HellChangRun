using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "PlayerInputReader", menuName = "Input/PlayerInputReader")]
public class PlayerInputReader : ScriptableObject, PlayerInputActions.IPlayerActions
{
    public event UnityAction<int> Move = delegate { };
    public event UnityAction<bool> Jump = delegate { };

    PlayerInputActions inputActions;

    public float Direction => inputActions.Player.Move.ReadValue<float>();

    void OnEnable()
    {
        if(inputActions == null)
        {
            inputActions = new PlayerInputActions();
            inputActions.Player.SetCallbacks(this);
        }
    }

    public void EnablePlayerActions()
    {
        inputActions.Enable();
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            if (Direction < 0)
            {
                Move.Invoke(-1);
            }
            else if(Direction > 0)
            {
                Move.Invoke(1);
            }
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                Jump.Invoke(true);
                break;
            case InputActionPhase.Canceled:
                Jump.Invoke(false);
                break;
        }
    }    
}
