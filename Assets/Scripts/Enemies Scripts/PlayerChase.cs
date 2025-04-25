using UnityEngine;
using Enemy;
using TMPro;
public class PlayerChase : Node
{
    private Transform _transform;

    public  PlayerChase(Transform transform)
    {
        _transform = transform;
    }

    public override Nodestate Evaluate()
    {
        Transform target = (Transform)GetData("target");
        if (Vector2.Distance(_transform.position, target.position) > 0.01f)
        {
            _transform.position = Vector2.MoveTowards(
                _transform.position, target.position, EnemyMelee.speed * Time.deltaTime);

        }
        state = Nodestate.RUNNING;
        return state;
    }
}
