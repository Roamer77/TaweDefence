using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform _target;

    [SerializeField]
    private ParticleSystem _bulletDestroyEffect;

    public float Speed = 15f;
    public int DamageValue = 20;
    public float ExplotionRadios = 0f;
    public void Seek (Transform target)
    {
        _target = target;
    }
    void Update()
    {
        if(_target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = _target.position - transform.position;
        float distanceThisFrame = Speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(_target);
    }

    private void HitTarget()
    {
        ParticleSystem effectIns = Instantiate(_bulletDestroyEffect, transform.position, transform.rotation);
        Destroy(effectIns.gameObject, 2f);

        if(ExplotionRadios > 0f)
        {
            Expload();
        }
        else
        {
            Damage(_target);
        }

        Destroy(gameObject);
    }

    private void Expload()
    {
       Collider[] colliders = Physics.OverlapSphere(transform.position, ExplotionRadios);
       foreach (var collider in colliders)
       {
           if(collider.CompareTag("Enemy"))
           {
               Damage(collider.transform);
           }
       }
    }
    private void Damage(Transform enemy)
    {
        Enemy instanceEnemy = enemy.GetComponent<Enemy>();
        if(instanceEnemy != null)
        {
            instanceEnemy.TakeDamage(DamageValue);
        }
        
    }

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ExplotionRadios);   
    }
}
