using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private UnityEvent _healthChanged;
    [SerializeField] private UnityEvent _damageTaken;
    [SerializeField] private UnityEvent _death;
    
    private float _minHealth;
    private float _currentHealth;
    private float _timeToDestruction = 2;

    public float CurrentHealth => _currentHealth;

    private void Awake()
    {
        _minHealth = 0;
        _currentHealth = _maxHealth;
    }

    public void Restore(float restoreValue)
    {
        _currentHealth += restoreValue;
        _currentHealth = Mathf.Clamp(_currentHealth, _minHealth, _maxHealth);
        _healthChanged?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        Restore(-damage);
        _damageTaken?.Invoke();        

        if (_currentHealth <= 0) 
        {
            _death?.Invoke();
            Die();
        }
    }

    private void Die()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f,0.0f);
        GetComponent<Rigidbody2D>().isKinematic = true;
        Destroy(gameObject, _timeToDestruction);
    }
}
