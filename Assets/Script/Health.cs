using UnityEngine;
using UnityEngine.Events;

[RequireComponent (typeof(Animator))]
[RequireComponent(typeof(Collider2D))]
public class Health : MonoBehaviour
{
    private const string Hurt = "Hurt";
    private const string IsDead = "isDead";

    [SerializeField] private int _maxHealth;
    
    private float _minHealth;
    private Animator _animator;
    private float _currentHealth;
    private int _hurtIndex;
    private int _isDeadIndex;
    private float _timeToDestruction = 2;

    public float CurrentHealth => _currentHealth;

    public UnityAction HealthChanged;

    private void Awake()
    {
        _minHealth = 0;
        _animator = GetComponent<Animator>(); 
        _currentHealth = _maxHealth;
        _hurtIndex = Animator.StringToHash(Hurt);
        _isDeadIndex = Animator.StringToHash(IsDead);
    }

    public void Restore(float restoreValue)
    {
        _currentHealth += restoreValue;
        _currentHealth = Mathf.Clamp(_currentHealth, _minHealth, _maxHealth);
        HealthChanged?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        Restore(-damage);
        _animator.SetTrigger(_hurtIndex);

        if (_currentHealth <= 0) 
        {
            Die();
        }
    }

    private void Die()
    {
        _animator.SetBool(_isDeadIndex, true);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f,0.0f);
        GetComponent<Rigidbody2D>().isKinematic = true;
        Destroy(gameObject, _timeToDestruction);
    }
}
