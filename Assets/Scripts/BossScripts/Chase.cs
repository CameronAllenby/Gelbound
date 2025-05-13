using Enemies;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Chase : StateEnemy
{
    
    public Chase(Boss enemy, StateMachineEnemy sm) : base(enemy, sm)
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
        //Debug.Log("checking for run");

        base.LogicUpdate();

        if (Vector2.Distance(boss.transform.position, boss.target.position) < boss.stoppingDistance)
        {
            boss.transform.position = Vector2.MoveTowards(boss.transform.position, boss.target.position, boss.speed * Time.deltaTime);
        }
    }   




    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }
}
