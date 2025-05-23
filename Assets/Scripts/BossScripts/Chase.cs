using Enemies;
using UnityEngine;
using System.Collections;
using static UnityEngine.GraphicsBuffer;

public class Chase : StateEnemy
{
    
    public Chase(Boss enemy, StateMachineEnemy sm) : base(enemy, sm)
    {
    }
    // Start is called before the first frame update
    private Transform target;
    public override void Enter()
    {
        base.Enter();
        boss.StartCoroutine("shoot");
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public override void Exit()
    {
        base.Exit();
        boss.StopCoroutine("shoot");
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void LogicUpdate()
    {
        //Debug.Log("checking for run");

        base.LogicUpdate();
        boss.anim.Play("walk");
        boss.transform.position = Vector2.MoveTowards(boss.transform.position, target.position, boss.speed * Time.deltaTime);
        boss.CheckForInactive();
        boss.CheckForAttack();
    }   




    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }
}
