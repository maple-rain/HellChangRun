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
        Debug.Log("슬라이딩");
        player.HandleMove();
        player.HandleSlide();
    }
}
