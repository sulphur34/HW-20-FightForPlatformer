using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class AnimatorHandler : MonoBehaviour
{
    private const string HorizontalSpeed = "HorizontalSpeed";
    private const string Attack = "Attack";
    private const string IsDead = "isDead";
    private const string VerticalSpeed = "VerticalSpeed";
    private const string Hurt = "Hurt";

    private int _horizontalSpeedIndex;
    private int _verticalSpeedIndex;
    private int _attackIndex;
    private int _isDeadIndex;
    private int _hurtIndex;

    private Animator _animator;
    private Rigidbody2D _rigidBody;

    private void Start()
    {
        _horizontalSpeedIndex = Animator.StringToHash(HorizontalSpeed);
        _verticalSpeedIndex = Animator.StringToHash(VerticalSpeed);
        _attackIndex = Animator.StringToHash(Attack);
        _hurtIndex = Animator.StringToHash(Hurt);
        _isDeadIndex = Animator.StringToHash(IsDead);
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _animator.SetFloat(_horizontalSpeedIndex,
            Mathf.Abs(_rigidBody.velocity.x));
        _animator.SetFloat(_verticalSpeedIndex,
            Mathf.Abs(_rigidBody.velocity.y));
    }    

    public void OnAttack()
    {
        _animator.SetTrigger(_attackIndex);
    }

    public void OnHurt()
    {
        _animator.SetTrigger(_hurtIndex);
    }

    public void OnDeath()
    {
        _animator.SetBool(_isDeadIndex, true);
    }
}
