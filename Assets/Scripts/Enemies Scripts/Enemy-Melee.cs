using UnityEngine;
using Enemy;
using System.Collections.Generic;
public class EnemyMelee : Oak
{
    public UnityEngine.Transform[] waypoints;

    public static float speed = 2f;
    public static float FOVrange= 6f;

    public static float attackRange = 1f;
 
    protected override Node SetupTree()
    {
        Node root = new PlayerSpot(transform);
        {
            /*new sequence(new List<Node>
            {
                new AttackPlayer(transform),
                new TaskAttack(transform),
            }),
            new sequence(new List<Node>
            {
                new PlayerSpot(transform),
                new PlayerChase(transform),
            }),
            new Patrol(transform, waypoints),*/
        };
        return root;
    }

}
