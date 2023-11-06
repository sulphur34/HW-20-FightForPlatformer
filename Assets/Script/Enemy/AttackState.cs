using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Attacker))]
public class AttackState : State
{
    [SerializeField] private State _nextState;
    [SerializeField] private UnityEvent _attackEvent;

    private float _attackDistance = 0.4f;
    
    public override State Run()
    {
        if (IsInRange(_attackDistance) == false)
            return _nextState;

        float stopSpeed = 0f;
        Mover.MoveHorizontal(stopSpeed);

        _attackEvent.Invoke();

        return this;
    }
}
