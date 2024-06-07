using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpState : BaseState
{
    public DoubleJumpState(PlayerController player, Animator animator) : base(player, animator)
    {
    }

    public override void OnEnter()
    {
        Debug.Log("DoubleJumpState.OnEnter");
        animator.CrossFade(DoubleJumpHash, crossFadeDuration);
    }
    public override void FixedUpdate()
    {
        //플레이어 점프와 움직임 로직 호출
        player.HandleJump();
        player.HandleMove();
    }
}
