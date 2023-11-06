using UnityEngine;

[RequireComponent (typeof(Flipper))]
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Attacker))]
public abstract class State : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private Flipper _flipper;
    private Mover _mover;
    private Attacker _attack;

    public Flipper Flipper => _flipper;
    public Attacker Attack => _attack;
    public Mover Mover => _mover;

    private void Start()
    {
        _flipper = GetComponent<Flipper> ();
        _attack = GetComponent<Attacker> ();
        _mover = GetComponent<Mover> ();
    }

    public abstract State Run();
    
    protected bool IsInRange(float range)
    {
        float minOffsetY = 0.3f;
        float distanceX = Mathf.Abs(_target.position.x - transform.position.x);
        float distanceY = Mathf.Abs(_target.position.y - transform.position.y);
        return distanceX <= range && distanceY <= minOffsetY;
    }

    protected Vector3 GetTargetPosition()
    {
        return _target.position;
    }
}
