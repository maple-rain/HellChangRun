using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : BaseState
{
    public RunState(PlayerController player, Animator animator) : base(player, animator) { }

    public override void OnEnter()
    {
        animator.CrossFade(RunHash, crossFadeDuration);
    }

    public override void FixedUpdate()
    {
        player.HandleMove();
    }
}
