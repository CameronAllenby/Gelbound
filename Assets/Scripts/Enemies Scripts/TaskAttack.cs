using UnityEngine;
using Enemy;
using Player;
public class TaskAttack : Node
{
    private Transform _lastTarget;
    private PlayerScript _playerDamage;

    private float _AttackTime = 1;
    private float _attackCounter = 0;
   public TaskAttack(Transform transform)
   {

   }

    public override Nodestate Evaluate()
    {
        Transform target = (Transform)GetData("target");

        if (target != _lastTarget)
        {
            _playerDamage = target.GetComponent<PlayerScript>();
            _lastTarget = target;
        }

        _attackCounter += Time.deltaTime;
        if ( _attackCounter >= _AttackTime )
        {
            _playerDamage.TakeDamage(10);
        }
        state = Nodestate.RUNNING;
        return state;

    }

}
