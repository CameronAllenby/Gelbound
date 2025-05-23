using Enemies;
using UnityEngine;
using System.Collections;
using static UnityEngine.GraphicsBuffer;
using UnityEditor;

public class Death : StateEnemy
{
    
    public Death(Boss enemy, StateMachineEnemy sm) : base(enemy, sm)
    {
    }
    // Start is called before the first frame update
    private Transform target;
    public override void Enter()
    {
        base.Enter();
        boss.anim.Play("death");
        
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
        //Debug.Log("checking for run");

        base.LogicUpdate();
    }   




    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }
}
