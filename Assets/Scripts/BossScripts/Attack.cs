using Enemies;
using UnityEngine;
using System.Collections;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Attack : StateEnemy
{

    public Attack(Boss enemy, StateMachineEnemy sm) : base(enemy, sm)
    {
    }
    // Start is called before the first frame update
    public override void Enter()
    {
        base.Enter();
        boss.StartCoroutine("Attacking");
    }

    public override void Exit()
    {
        base.Exit();
        boss.StopCoroutine("Attacking");
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void LogicUpdate()
    {
        //Debug.Log("checking for run");

        base.LogicUpdate();

        boss.CheckForChase();
        boss.CheckForInactive();
        
    }


    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }
}