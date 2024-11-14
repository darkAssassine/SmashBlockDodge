using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Action Died;

    [SerializeField] float MaxHealth;

    private float health;
    private bool isAlive;

    public void TryTakeDamage(float damage)
    {
        if (isAlive)
        {
            health -= Mathf.Abs(damage);
            if (health <= 0)
            {
                Die();
            }
        }
    }

    public void TryHeal(float healAmount)
    {
        if (isAlive)
        {
            health += Mathf.Abs(healAmount);
            if (health > MaxHealth)
            {
                health = MaxHealth;
            }
        }
    }

    private void Die()
    {
        Died?.Invoke();
    }
}
