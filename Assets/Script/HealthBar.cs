using TMPro;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Health _health;
    [SerializeField] TextMeshProUGUI _healthValue;

    private void Start()
    {
        OnHealthChanged();
    }

    public void OnHealthChanged()
    {
       _healthValue.text = _health.CurrentHealth.ToString();
    }
}
