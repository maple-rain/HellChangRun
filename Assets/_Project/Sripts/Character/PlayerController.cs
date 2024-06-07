using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] CapsuleCollider capsuleCollider;
    [SerializeField] Animator animator;
    [SerializeField] PlayerInputReader playerInputReader;
    [SerializeField] LayerMask groundLayer;

    [Header("Movement Settings")]
    [SerializeField] float initialSpeed = 6f;
    //[SerializeField] float maximumSpeed = 30f;
    //[SerializeField] float playerSpeedIncreaseRate = 0.1f;
    //[SerializeField] float playerSpeedDecreaseRate = -0.1f;
    

    [Header("Jump Settings")]
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float jumpDuration = 0.5f;
    [SerializeField] float jumpCooldown = 0f;
    [SerializeField] float gravityMultiplier = 3f;

    [Header("Lane Position")]
    [SerializeField] const float laneDistance = 8f;
    [SerializeField] float laneSwitchSpeed= 10f;
    [SerializeField] float smoothTime = 0.2f;
    int currentLane = 0;

    Vector3 moveVector = Vector3.zero;
    bool isSwitching;
    const float ZeroF = 0f;
    float currentSpeed;
    float velocity;
    float jumpVelocity;

    List<Timer> timers;
    CountdownTimer jumpTimer;
    CountdownTimer jumpCooldownTimer;
    CharacterController characterController;
    StateMachine stateMachine;

    private void Awake()
    {
       capsuleCollider = GetComponent<CapsuleCollider>();
        characterController= GetComponent<CharacterController>();
        //groundChecker = GetComponent<GroundChecker>();
        SetupTimers();
        SetupStates();
    }

    private void SetupStates()
    {
        stateMachine = new StateMachine();

        var runState = new RunState(this, animator);
        var jumpState = new JumpState(this,animator);

        At(runState, jumpState, new FuncPredicate(() => jumpTimer.IsRunning));
        Any(runState, new FuncPredicate(ReturnToRunState));

        stateMachine.SetState(runState); 
    }

    void At(IState from, IState to, IPredicate condition) => stateMachine.AddTransition(from, to, condition);
    void Any(IState to, IPredicate condition) => stateMachine.AddAnyTransition(to, condition);

    bool ReturnToRunState()
    {
        return IsGrounded() && !jumpTimer.IsRunning;
    }

    private void SetupTimers()
    {
        jumpTimer = new CountdownTimer(jumpDuration);
        jumpCooldownTimer = new CountdownTimer(jumpCooldown);

        jumpTimer.OnTimerStart += () => jumpVelocity = jumpForce;
        jumpTimer.OnTimerStop += () => jumpCooldownTimer.Start();

        timers = new List<Timer>(2) { jumpTimer,jumpCooldownTimer };
    }

    private void Start() => playerInputReader.EnablePlayerActions();
    
    
    private void OnEnable()
    {
        playerInputReader.Move += OnMove;
        playerInputReader.Jump += OnJump;
    }

    private void OnDisable()
    {
        playerInputReader.Move -= OnMove;
        playerInputReader.Jump -= OnJump;
    }

    private void Update()
    { 
        stateMachine.Update();
       HandleTimers();
    }
    private void FixedUpdate()
    {
      
        stateMachine.FixedUpdate();
        //HandleMove();
        //HandleJump();
        
    }

    void HandleTimers()
    {
        foreach (var timer in timers)
        {
            timer.Tick(Time.deltaTime);
        }
    }

    private void OnJump(bool performed)
    {
        if(performed && !jumpTimer.IsRunning && !jumpCooldownTimer.IsRunning && IsGrounded())
        {
            jumpTimer.Start();
            jumpVelocity = jumpForce;
        }
        else if(!performed && jumpTimer.IsRunning)
        {
            jumpTimer.Stop();
        }
    }

    public void OnMove(int direction)
    {
        if (isSwitching) return;
        CheckCurrentLane();

       Vector3 targetPosition = characterController.transform.position;

        if (direction == -1 && currentLane >=0 && isSwitching ==false ) //왼쪽 방향키
        {         
            currentLane--;
            targetPosition += Vector3.left * laneDistance;
            
            StartCoroutine(SmoothMove(targetPosition));
        }
        else if (direction == 1 && currentLane <1 && isSwitching == false) //오른쪽 방향키
        {
            
            currentLane++;
            targetPosition += Vector3.right * laneDistance;
            StartCoroutine(SmoothMove(targetPosition));

        }
        isSwitching = false;

       
        Debug.Log(direction);
    }

    private void CheckCurrentLane()
    {
        if (currentLane == -2)
        {
            currentLane = -1;
            return;
        }
        if (currentLane == 2)
        {
            currentLane = 1;
            return;
        }
    }

    private IEnumerator SmoothMove(Vector3 targetPosition) 
    {
        float targetRotation = 0f;
        if(targetPosition.x > characterController.transform.position.x)
        {
            targetRotation = 50f;
        }
        else if(targetPosition.x < characterController.transform.position.x)
        {
            targetRotation = -50f;
        }

        while (Mathf.Abs(characterController.transform.position.x - targetPosition.x) > 0.05f)
        {            
            float direction = Mathf.Sign(targetPosition.x - characterController.transform.position.x);            
            characterController.Move(new Vector3(laneSwitchSpeed * Time.deltaTime * direction, 0f, 0f));


            //플레이어 회전
            Quaternion currentRotation = characterController.transform.rotation;
            Quaternion targetQuaternion = Quaternion.Euler(0,targetRotation,0);
            characterController.transform.rotation = Quaternion.Lerp(currentRotation, targetQuaternion,Time.deltaTime * laneSwitchSpeed);

            isSwitching = true;
            yield return null;
        }

        //플레이어 위치 스내핑
        Vector3 finalPosition = characterController.transform.position;
        finalPosition.x = Mathf.RoundToInt(finalPosition.x / 4) * 4;
        characterController.transform.position = finalPosition;
        //플레이어 회전 리셋
        characterController.transform.rotation = Quaternion.Euler(0,0,0);

        isSwitching = false;             
    }

    public void HandleMove()
    {
        characterController.Move(transform.forward * initialSpeed * Time.deltaTime);
    }

    public void HandleJump()
    {
        if(!jumpTimer.IsRunning && IsGrounded())
        {
            jumpVelocity = ZeroF;
            jumpTimer.Stop();
            return;
        }

        if(!jumpTimer.IsRunning)
        {
            jumpVelocity += Physics.gravity.y * gravityMultiplier * Time.fixedDeltaTime;
        }

        Vector3 jumpVector = new Vector3(0,jumpVelocity,0);
        characterController.Move(jumpVector * Time.fixedDeltaTime);
    }

    private bool IsGrounded(float length = 0.5f)
    {
        Vector3 raycastOriginFirst = transform.position;
        raycastOriginFirst.y -= capsuleCollider.height / 2f;
        raycastOriginFirst.y += 0.1f;

        Vector3 raycastOriginSecond = raycastOriginFirst;
        raycastOriginFirst -= transform.forward * 0.2f;
        raycastOriginSecond += transform.forward * 0.2f;

        Debug.DrawLine(raycastOriginFirst, Vector3.down, Color.red, 2f);

        if (Physics.Raycast(raycastOriginFirst, Vector3.down, out RaycastHit hit, length, groundLayer) ||
            Physics.Raycast(raycastOriginSecond, Vector3.down, out RaycastHit hit2, length, groundLayer))
        {
            return true;
        }
        return false;



    }
}
