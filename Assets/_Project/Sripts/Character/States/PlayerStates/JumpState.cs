using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : BaseState
{
    public JumpState(PlayerController player, Animator animator) : base(player, animator)
    {

    }

    public override void OnEnter()
    {
        Debug.Log("JumpState.OnEnter");
        animator.CrossFade(JumpHash, crossFadeDuration);
    }

    public override void FixedUpdate()
    {

        //�÷��̾� ������ ������ ���� ȣ��
        player.HandleJump();
        player.HandleMove();
    }
}
