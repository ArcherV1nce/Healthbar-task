using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private Health _health;

    public string Name => _name;
    public float Health => _health.Value;
    public float HealthFull => _health.FullValue;

    public UnityEvent OnHealthChange;

    private void OnValidate()
    {
        _health.Validate();
    }

    public void TakeDamage (Damage damage)
    {
        _health.TakeDamage(damage);
        OnHealthChange.Invoke();
    }

    public void Heal (Healing healing)
    {
        _health.Heal(healing);
        OnHealthChange.Invoke();
    }
}