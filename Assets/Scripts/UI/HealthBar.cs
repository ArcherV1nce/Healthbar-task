using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    private const float AnimationDurationMin = 1f;
    private const float AnimationDurationMax = 60f;

    [SerializeField] private Character _character;
    [SerializeField] [Range(AnimationDurationMin, AnimationDurationMax)] 
    private float _animationDuration;

    private Slider _slider;

    private void Awake()
    {
        SetUp();
    }

    private void OnValidate()
    {
        _animationDuration = _animationDuration < AnimationDurationMin ? AnimationDurationMin : _animationDuration;
        _animationDuration = _animationDuration > AnimationDurationMax ? AnimationDurationMax : _animationDuration;
    }

    private void Update()
    {
        ShowCurrentHealth();
    }

    private void ShowCurrentHealth ()
    {
        _slider.value = Mathf.MoveTowards(_slider.value, 
            _character.Health/_character.HealthFull, 
            Time.deltaTime / _animationDuration);
    }

    private void SetUp ()
    {
        _slider = GetComponent<Slider>();
        _slider.value = _character.Health / _character.HealthFull;
    }
}