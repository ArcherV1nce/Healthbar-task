using UnityEngine;

public class Healer : MonoBehaviour
{
    [SerializeField] private Healing _healing;
    [SerializeField] private Character _target;

    public void Heal()
    {
        _target.Heal(_healing);
    }
}