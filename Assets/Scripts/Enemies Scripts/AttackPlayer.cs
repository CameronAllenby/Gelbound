using UnityEngine;
using Enemy;
using TMPro;
public class AttackPlayer : Node
{
    private static int _PlayerLayerMask = 1 << 7;

    private Transform _transform;
    public AttackPlayer(Transform transform)
    {
        transform = _transform;
    }

    public override Nodestate Evaluate()
    {
        object t = GetData("targit");
        if (t != null)
        {
            state = Nodestate.FAILURE;
            return state;
        }
        Transform target = (Transform)t;
        if (Vector2.Distance(_transform.position, target.position) <= EnemyMelee.attackRange)
        {
            state = Nodestate.SUCCESS;
            return state;
        }
        state = Nodestate.FAILURE;
        return state;
    }
}
