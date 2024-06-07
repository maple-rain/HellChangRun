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
        //�÷��̾� ������ ������ ���� ȣ��
        player.HandleJump();
        player.HandleMove();
    }
}
