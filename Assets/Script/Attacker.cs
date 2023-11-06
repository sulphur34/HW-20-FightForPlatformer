using UnityEngine;
using UnityEngine.Events;

public class Attacker : MonoBehaviour
{
    [SerializeField] private int _damageValue;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private UnityEvent _attackEvent;

    private float _attackRange = 0.2f;
    private float _attackRate = 2f;
    private float _nextAttackTime = 0f;

    public void InflictDamage()
    {
        if (Time.time >= _nextAttackTime)
        {
            _attackEvent.Invoke();
            Collider2D[] enemies =
                Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange);

            foreach (Collider2D enemy in enemies)
            {
                if (enemy.gameObject != _attackPoint.parent.gameObject
                    && enemy.TryGetComponent(typeof(Health), out Component health))
                {
                    ((Health)health).TakeDamage(_damageValue);
                }
            }

            _nextAttackTime = Time.time + 1f / _attackRate;            
        }
    }
}
