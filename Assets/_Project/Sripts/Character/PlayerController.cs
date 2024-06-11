using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] CapsuleCollider capsuleCollider;
    [SerializeField] Animator animator;
    [SerializeField] PlayerInputReader playerInputReader;
    [SerializeField] LayerMask groundLayer;

    [Header("Movement Settings")]
    public float initialSpeed = 10f;

    [Header("Jump Settings")]
    [SerializeField] float jumpForce = 15f;
    [SerializeField] float doubleJumpForce = 20f;
    [SerializeField] float jumpDuration = 0.5f;
    [SerializeField] float jumpCooldown = 0f;
    [SerializeField] float gravityMultiplier = 3f;
    private int numberOfJumps;
    public int maxNumberOfJumps = 2;

    [Header("Sliding Settings")]
    [SerializeField] float slideDuration = 0.5f;
    [SerializeField] float slideCoolDown = 0.5f;
    [SerializeField] AnimationClip slideAnimationClip;
    private bool sliding = false;
    

    [Header("Lane Position")]
    [SerializeField] float laneDistance = 8f;
    [SerializeField] float laneSwitchSpeed= 10f;
    [SerializeField] float smoothTime = 0.2f;
    int currentLane = 0;

    Vector3 moveVector = Vector3.zero;
    bool isSwitching;
    const float ZeroF = 0f;
    float jumpVelocity;

    List<Timer> timers;
    CountdownTimer jumpTimer;
    CountdownTimer jumpCooldownTimer;
    CountdownTimer slideTimer;
    CountdownTimer slideCooldownTimer;
    CharacterController characterController;
    StateMachine stateMachine;

    public GameObject QuickSlot;
    public bool toggleInven;
    public WeightController weightController;
    private void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        characterController= GetComponent<CharacterController>();
        weightController = GetComponent<WeightController>();
        //groundChecker = GetComponent<GroundChecker>();
        SetupTimers();
        SetupStates();
    }

    private void SetupStates()
    {
        stateMachine = new StateMachine();

        var runState = new RunState(this, animator);
        var jumpState = new JumpState(this,animator);
        var doubleJumpState = new DoubleJumpState(this,animator);
        var slideState = new SlideState(this,animator);

        At(runState, jumpState, new FuncPredicate(() => jumpTimer.IsRunning));
        At(jumpState,doubleJumpState, new FuncPredicate(() => jumpTimer.IsRunning && numberOfJumps ==2));
        At(runState, slideState, new FuncPredicate(() => slideTimer.IsRunning));
        Any(runState, new FuncPredicate(ReturnToRunState));

        stateMachine.SetState(runState); 
    }

    void At(IState from, IState to, IPredicate condition) => stateMachine.AddTransition(from, to, condition);
    void Any(IState to, IPredicate condition) => stateMachine.AddAnyTransition(to, condition);

    bool ReturnToRunState()
    {
        return IsGrounded() && !jumpTimer.IsRunning && !slideTimer.IsRunning;
    }

    private void SetupTimers()
    {
        jumpTimer = new CountdownTimer(jumpDuration);
        jumpCooldownTimer = new CountdownTimer(jumpCooldown);
        jumpTimer.OnTimerStart += () => jumpVelocity = jumpForce;
        jumpTimer.OnTimerStop += () => jumpCooldownTimer.Start();

        slideTimer = new CountdownTimer(slideDuration);
        slideCooldownTimer = new CountdownTimer(slideCoolDown);
        slideTimer.OnTimerStart += () => slideCooldownTimer.Stop();
        slideTimer.OnTimerStart += () => slideCooldownTimer.Start();
        
        timers = new List<Timer>(4) { jumpTimer,jumpCooldownTimer,slideCooldownTimer,slideTimer};
    }

    private void Start() => playerInputReader.EnablePlayerActions();
       
    private void OnEnable()
    {
        playerInputReader.Move += OnMove;
        playerInputReader.Jump += OnJump;
        playerInputReader.DoubleJump += OnDoubleJump;
        playerInputReader.Slide += OnSlide;
        playerInputReader.Inventory += OnInventory;
        playerInputReader.ItemUse += OnItemUse;
    }

    private void OnDisable()
    {
        playerInputReader.Move -= OnMove;
        playerInputReader.Jump -= OnJump;
        playerInputReader.DoubleJump -= OnDoubleJump;
        playerInputReader.Slide -= OnSlide;
        playerInputReader.Inventory -= OnInventory;
        playerInputReader.ItemUse -= OnItemUse;
    }

    private void Update()
    { 
        stateMachine.Update();
       HandleTimers();
       
        if(IsGrounded() && !jumpTimer.IsRunning)
        {
            numberOfJumps = 0;
        }
        Debug.Log(numberOfJumps);
    }
    
    private void FixedUpdate()
    {     
        stateMachine.FixedUpdate();      
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
        if(performed && numberOfJumps ==0 && !jumpTimer.IsRunning && !jumpCooldownTimer.IsRunning 
           && IsGrounded())
        {
            numberOfJumps++;
            jumpTimer.Start();
            jumpVelocity = jumpForce;
        }
        else if(!performed && jumpTimer.IsRunning )
        {
            jumpTimer.Stop();
            
        }
    }

    private void OnDoubleJump(bool performed)
    {
        if(performed && numberOfJumps ==1
            && numberOfJumps < maxNumberOfJumps && !jumpTimer.IsRunning && !jumpCooldownTimer.IsRunning)
        {
            numberOfJumps++;
            jumpTimer.Start();
            jumpVelocity = doubleJumpForce;
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
    }
    private void OnInventory(bool Inventory)
    {
        if(Inventory)
        {
            QuickSlot.SetActive(true);
            toggleInven = true;
            
        }
        else
        {
            QuickSlot.SetActive(false);
            toggleInven = false;
        }
    }
    private void OnItemUse(int Input)
    {
        Debug.Log(toggleInven);
        Debug.Log(ItemManager.Instance.SelectedItemDates[Input]);
        //인벤토리가 켜지고, 데이터가 있을 때 => 해당 데이터의 value값을 플레이어에게 적용한다
        if (toggleInven && ItemManager.Instance.SelectedItemDates[Input] != null)
        {
            ItemData selectedItem = ItemManager.Instance.SelectedItemDates[Input];
            foreach (ItemDataConsumable consumable in selectedItem.coumsumables)
            {
                // 소비 가능한 아이템의 효과를 적용
                switch (consumable.type)
                {
                    case ConsumableType.Weight:
                        ApplyWeightConsumable(consumable.value);
                        break;
                    case ConsumableType.Speed:
                        ApplySpeedConsumable(consumable.value);
                        break;
                    case ConsumableType.trap:
                        ApplyTrapConsumable(consumable.value);
                        break;
                }
            }
        }
    }
    private void ApplyWeightConsumable(float value)
    {
        weightController.Consume(value);
    }

    private void ApplySpeedConsumable(float value)
    {
        initialSpeed += value;
    }

    private void ApplyTrapConsumable(float value)
    {
        Debug.Log("적에게 적용 " + value);
    }


    public void OnSlide(bool performed)
    {
        if(performed && IsGrounded() && !slideTimer.IsRunning)
        {
            slideTimer.Start();           
        }
        else if(!performed && slideTimer.IsRunning)
        {
            slideTimer.Stop();
        }
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

    public void HandleSlide()
    {
        if (!slideTimer.IsRunning && !sliding)
        {
            slideTimer.Stop();
            return;
        }
        if (!slideTimer.IsRunning && IsGrounded() &&!sliding)
        {
            StartCoroutine(Slide());
        }
    }

    public IEnumerator Slide()
    {
        //콜라이더 크기 조정
        Vector3 originalControllerCenter = characterController.center;
        Vector3 newControllerCenter = originalControllerCenter;
        characterController.height /= 2;
        newControllerCenter.y -= characterController.height / 2;
        characterController.center = newControllerCenter;

        sliding = true;

        yield return new WaitForSeconds(slideAnimationClip.length);

        characterController.height *= 2;
        characterController.center = originalControllerCenter;
        sliding = false;
    }
    private bool IsGrounded(float length = 0.7f)
    {
        Vector3 raycastOriginFirst = transform.position;
        raycastOriginFirst.y -= capsuleCollider.height / 2f;
        raycastOriginFirst.y += 0.1f;

        Vector3 raycastOriginSecond = raycastOriginFirst;
        raycastOriginFirst -= transform.forward * 0.2f;
        raycastOriginSecond += transform.forward * 0.2f;

        //Debug.DrawLine(raycastOriginFirst, Vector3.down, Color.red, 2f);

        if (Physics.Raycast(raycastOriginFirst, Vector3.down, out RaycastHit hit, length, groundLayer) ||
            Physics.Raycast(raycastOriginSecond, Vector3.down, out RaycastHit hit2, length, groundLayer))
        {
            return true;
        }
        return false;
    }
}
