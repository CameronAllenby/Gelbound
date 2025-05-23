using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using System.Security.Cryptography;

public class Move : State
{
    // Start is called before the first frame update
    public Move(PlayerScript player, StateMachine sm) : base(player, sm)
    {

    }
    // Start is called before the first frame update
    public override void Enter()
    {
        base.Enter();
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
        base.LogicUpdate();
        player.anim.Play("run");


        if (Input.GetAxis("Horizontal") !=0)
        {
            player.rb.AddForce(new Vector3(0.5f * Input.GetAxis("Horizontal"), 0, 0));
            if (Input.GetAxis("Horizontal") == -1)
            {
                player.sr.flipX = false;
            }
            if (Input.GetAxis("Horizontal") == 1)
            {
                player.sr.flipX = true;
            }
            player.flip = false;
        }
        
        
        player.CheckForIdle();

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }

    
    
}
