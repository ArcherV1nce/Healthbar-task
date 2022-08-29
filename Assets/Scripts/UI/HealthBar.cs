using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    private const float AnimationDurationMin = 1f;
    private const float AnimationDurationMax = 60f;
    private const int AnimationStepsPerSecond = 50;

    [SerializeField] private Character _character;
    [SerializeField] [Range(AnimationDurationMin, AnimationDurationMax)] 
    private float _animationDuration;
    [SerializeField] private bool _useDoTween;

    private Coroutine _healthbarUpdate;
    private float _lastSliderValue;
    private float _animationStepsCount;
    private Slider _slider;

    private void Awake()
    {
        SetUp();
    }

    private void OnValidate()
    {
        ValidateAnimation();
    }

    public void ShowCurrentHealth()
    {
        float healthToSliderValue = _character.Health / _character.HealthFull;

        if (CheckHealthChanges(healthToSliderValue))
        {
            if (_healthbarUpdate != null)
            {
                StopCoroutine(_healthbarUpdate);
            }

            if (_useDoTween)
            {
                _slider.DOValue(healthToSliderValue, _animationDuration);
            }

            else
            {
                _healthbarUpdate = StartCoroutine(AnimateHealthChange(_animationDuration));
            }
        }
    }

    private bool CheckHealthChanges(float healthToSliderValue)
    {
        bool healthChanged = false;

        if (_lastSliderValue != healthToSliderValue)
        {
            _lastSliderValue = healthToSliderValue;
            healthChanged = true;
        }

        return healthChanged;
    }

    private IEnumerator AnimateHealthChange(float duration)
    {
        var waitForNextStep = new WaitForSecondsRealtime(duration / _animationStepsCount);
        float stepDistance = Mathf.Abs(_slider.value - _lastSliderValue) / _animationStepsCount;

        while (_slider.value != _lastSliderValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value,
                _lastSliderValue, stepDistance);
            yield return waitForNextStep;
        }
    }

    private void SetUp ()
    {
        _slider = GetComponent<Slider>();
        _slider.value = _character.Health / _character.HealthFull;
        _animationStepsCount = AnimationStepsPerSecond * _animationDuration;
    }

    private void ValidateAnimation()
    {
        _animationDuration = _animationDuration < AnimationDurationMin ? AnimationDurationMin : _animationDuration;
        _animationDuration = _animationDuration > AnimationDurationMax ? AnimationDurationMax : _animationDuration;
        _animationStepsCount = AnimationStepsPerSecond * _animationDuration;
    }
}