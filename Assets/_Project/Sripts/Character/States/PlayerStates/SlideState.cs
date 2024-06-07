using UnityEngine;

public class SlideState : BaseState
{
    public SlideState(PlayerController player, Animator animator) : base(player, animator)
    {
    }

    public override void OnEnter()
    {
        Debug.Log("SlideState.OnEnter");
        animator.CrossFade(SlideHash,crossFadeDuration);
    }

    public override void FixedUpdate()
    {
        player.HandleMove();
        player.HandleSlide();
    }
}
