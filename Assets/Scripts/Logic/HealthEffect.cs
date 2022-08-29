using System;
using UnityEngine;

public abstract class HealthEffect
{
    protected const float ValueMin = 0f;

    [SerializeField][Range(1f, 300f)] protected float _value;
    public float Value => _value;

    public HealthEffect (float value)
    {
        _value = value < ValueMin ? ValueMin : value;
    }
}