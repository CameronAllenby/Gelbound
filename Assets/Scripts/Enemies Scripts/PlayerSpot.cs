using UnityEngine;
using Enemy;

public class PlayerSpot : Node
{
    private Transform _transform;
    private static int _PlayerLayerMask = 1 << 7;
    public PlayerSpot(Transform transform)
    {
        _transform = transform;
    }

    public override Nodestate Evaluate()
    {
        object t = GetData("target");
        if (t == null)
        {
            Collider[] colliders = Physics.OverlapSphere(
                _transform.position, EnemyMelee.FOVrange, _PlayerLayerMask);

            if (colliders.Length > 0)
            {
                parent.parent.SetData("target", colliders[0].transform);
                state = Nodestate.SUCCESS;
                return state;

            }
            state = Nodestate.FAILURE;
        }
        state = Nodestate.SUCCESS;
        return state;
    }
}
