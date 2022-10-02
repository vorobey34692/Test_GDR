using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected int Damage;

    protected void Inicialize(int damage)
    {
        Damage = damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamageble damageble))
            damageble.ApplayDamage(Damage);
    }
}