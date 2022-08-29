using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private Character _target;
    [SerializeField] private Damage _damage;

    public void DealDamage ()
    {
        _target.TakeDamage(_damage);
    }
}