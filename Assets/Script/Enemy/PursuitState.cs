using UnityEngine;

public class PursuitState : State
{
    [SerializeField] private State _nextState;

    private float _speed = 0.5f;
    private float _attackDistance = 0.4f;

    public override State Run()
    {
        if(IsInRange(_attackDistance))
            return _nextState;

        Vector3 _targetPosition = GetTargetPosition();
        float distance = _targetPosition.x - _targetPosition.x;
        float followSpeed = _speed;

        if ((distance < 0 && _speed > 0) || (distance > 0 && _speed < 0))
            followSpeed = -followSpeed;

        Mover.MoveHorizontal(followSpeed);
        Flipper.FlipEvent();

        return this;
    }    
}
