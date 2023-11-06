using UnityEngine;

public class PatrolState : State
{
    [SerializeField] private State _nextState;
    [SerializeField] private float _followDistance = 1.5f;
    [SerializeField] private Transform _rightBorderWaypoint;
    [SerializeField] private Transform _leftBorderWaypoint;

    private Transform _currentWaypoint;
    private float _speed = 0.5f;

    private void Awake()
    {
        _currentWaypoint = _rightBorderWaypoint;
    }

    public override State Run()
    {
        if (IsInRange(_followDistance))
            return _nextState;

        float distance = Vector2.Distance(transform.position,
            _currentWaypoint.position);

        if (distance <= 0.5f && _currentWaypoint == _rightBorderWaypoint)
        {
            _currentWaypoint = _leftBorderWaypoint;
            _speed *= -1;
        }
        else if (distance <= 0.5f && _currentWaypoint == _leftBorderWaypoint)
        {
            _currentWaypoint = _rightBorderWaypoint;
            _speed *= -1;
        }

        Flipper.FlipEvent();
        Mover.MoveHorizontal(_speed);

        return this;
    }    
}
