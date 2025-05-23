using Enemies;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Inactive : StateEnemy
{

    public Inactive(Boss enemy, StateMachineEnemy sm) : base(enemy, sm)
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
        boss.anim.Play("idle");

        boss.CheckForChase();
        boss.CheckForAttack();
        boss.CheckForDeath();
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }
}
