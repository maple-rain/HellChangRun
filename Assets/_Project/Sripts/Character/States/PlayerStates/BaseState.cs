using UnityEngine;

public abstract class BaseState : IState
{
    protected readonly PlayerController player;
    protected readonly Animator animator;

    protected static readonly int RunHash = Animator.StringToHash("Run");
    protected static readonly int JumpHash = Animator.StringToHash("Jump");
    protected static readonly int DoubleJumpHash = Animator.StringToHash("DoubleJump");
    protected static readonly int SlideHash = Animator.StringToHash("Slide");

    protected const float crossFadeDuration = 0.1f;

    protected BaseState(PlayerController player, Animator animator)
    {
        this.player = player;
        this.animator = animator;
    }

    public virtual void OnEnter()
    {

    }

    public virtual void Update()
    {
        
    }

    public virtual void FixedUpdate()
    {
        
    }

    public virtual void OnExit()
    {
        
    }
}
