using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float StartSpeed = 10f;
    public float StartHealth = 100;

    public GameObject DeathEffect;

    [HideInInspector]
    private float _health = 100;
    public float Speed = 10f;

    [Header("Unity Stuff")]

    public Image HealthBar;

    public int MoneyValueForKill = 20;

    public bool isDead = false;
    private void Start()
    {
        Speed = StartSpeed;
        _health = StartHealth;
    }
    public void TakeDamage(float amount)
    {
        print("TakeDamage");
        _health -= amount;
        HealthBar.fillAmount = _health / StartHealth;
        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        print("enemy die");
        isDead = true;
        WaveSpawner.EnemysAlive--;
        PlayerStats.Money += MoneyValueForKill;
        var deathEffect = Instantiate(DeathEffect, transform.position, transform.rotation);
        Destroy(deathEffect.gameObject, 5f);
        
        Destroy(gameObject);
    }

    public void Slow(float amount)
    {
        Speed = StartSpeed * (1f - amount);
    }

}
