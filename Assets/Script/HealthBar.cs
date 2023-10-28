using TMPro;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Health _health;
    [SerializeField] TextMeshProUGUI _healthValue;

    private void Start()
    {
        _health.HealthChanged += OnHealthChanged;
        OnHealthChanged();
    }

    private void OnHealthChanged()
    {
       _healthValue.text = _health.CurrentHealth.ToString();
    }
}
