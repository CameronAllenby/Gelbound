using UnityEngine;
using Enemy;
public class Patrol : Node
{
    private Transform _transform;
    private Transform[] _waypoints;

    private int _currentWaypointIndex;

    private float _waitTime = 1f;
    private float _waitCounter = 0f;
    private bool _waiting = false;
    public Patrol(Transform transform , Transform[] waypoints)
    {
        _transform = transform;
        _waypoints = waypoints; 
    }
    public override Nodestate Evaluate()
    {
        if (_waiting)
        {
            _waitCounter += Time.deltaTime;
            if (_waitCounter >= _waitTime)
            {
                _waiting = false;
            }
            
        }
        else
        {
            Transform wp = _waypoints[_currentWaypointIndex];
            if (Vector2.Distance(_transform.position, wp.position) < 0.01f)
            {
                _transform.position = wp.position;
                _waitCounter = 0f;
                _waiting = true;
                

                _currentWaypointIndex = (_currentWaypointIndex+1)  % _waypoints.Length;
            }
            else
            {
                _transform.position = Vector2.MoveTowards(_transform.position, wp.position, EnemyMelee.speed * Time.deltaTime);
            }

        }
        state = Nodestate.RUNNING;
        return state;
    }
}
