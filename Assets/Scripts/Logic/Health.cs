using System;
using UnityEngine;

[Serializable]
public class Health
{
    private const float ValueMin = 0f;

    [SerializeField] [Range(1f, 300f)] private float _fullValue;
    [SerializeField] private float _value;
    
    public float FullValue => _fullValue;
    public float Value => _value < ValueMin ? ValueMin : _value;

    public Health (float fullValue, float value)
    {
        _fullValue = fullValue;
        _value = value > fullValue ? fullValue : value < ValueMin ? ValueMin : value;
    }

    public void TakeDamage (Damage damage)
    {
        _value -= damage.Value;
        _value = _value < ValueMin ? ValueMin : _value;
    }

    public void Heal (Healing healing)
    {
        _value += healing.Value;
        _value = _value > FullValue ? FullValue : _value;
    }

    public void Validate ()
    {
        _value = _value > _fullValue ? _fullValue : _value < ValueMin ? ValueMin : _value;
    }
}