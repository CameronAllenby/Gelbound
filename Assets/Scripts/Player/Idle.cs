using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using System.Security.Cryptography;

public class Idle : State
{
    // Start is called before the first frame update
    public Idle(PlayerScript player, StateMachine sm) : base(player, sm)
    {

    }
    // Start is called before the first frame update
    public override void Enter()
    {
        base.Enter();
        player.anim.Play("Idle");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void LogicUpdate()
    {
        if(player.ground == true)
        {
            player.anim.Play("Idle");
        }

        base.LogicUpdate();
        player.CheckForMovment();
        //player.CheckForInAir();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }

}
