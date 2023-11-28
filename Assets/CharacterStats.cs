using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    public Stat damage;
    public Stat maxHealth;

    [SerializeField] private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth.GetValue();

        damage.AddModifier(4);
    }

    public void TakeDamge(int _damage)
    {
        currentHealth -= _damage;

        if (currentHealth < 0)
        {

            Die();
        }
    }

    private void Die()
    {
        throw new NotImplementedException();
    }
}