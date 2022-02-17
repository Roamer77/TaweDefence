using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Atributes")]

    [SerializeField]
    private Transform _target;
    
    private Enemy _enemy;

    [SerializeField]
    private Transform _partToRotate;

   

    [SerializeField]
    private Transform firePosition;

    [Header("General")]
    public float Range = 15f;

    [Header("Use Bullets (default)")]
    public float FireRate = 1f;
    private float _fireCountdown = 0f;

    [SerializeField]
    private GameObject bulletPrefub;

    [Header("Use Laser")]
    public bool useLaser = false;

    public int damagePerSecond = 20;

    public float slowAmount = 0.3f;
    public LineRenderer LineRenderer;

    public ParticleSystem LaserImpactPatical;

    public Light LaserLight;

    [Header("Unity setup fields")]
    private float _turnSpeed = 10f;
   
    private string _enemyTag = "Enemy";


    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        
    }

    void Update()
    {
        if(_target == null)
        {
            if(useLaser)
            {
                if(LineRenderer.enabled)
                {
                    LineRenderer.enabled = false;
                    LaserImpactPatical.Stop();
                    LaserLight.enabled = false;
                }
            }
            return;
        }

        GetInTarget();

        if(useLaser)
        {
            Laser();
        }
        else
        {
            if(_fireCountdown <= 0f)
            {
                Shoot();
                _fireCountdown = 1f / FireRate;
            }
            _fireCountdown -= Time.deltaTime;
        }
        
    }

    private void Laser()
    {
        _enemy.TakeDamage(damagePerSecond * Time.deltaTime);
        _enemy.Slow(slowAmount);
        if(!LineRenderer.enabled)
        {
            LineRenderer.enabled = true;
            LaserImpactPatical.Play();
            LaserLight.enabled = true;
        }
        LineRenderer.SetPosition(0, firePosition.position);
        LineRenderer.SetPosition(1, _target.position);

        var direction = firePosition.position - _target.position;
        LaserImpactPatical.transform.position = _target.position + direction.normalized;
        LaserImpactPatical.transform.rotation = Quaternion.LookRotation(direction);
        
    }
    private void Shoot()
    {
        GameObject spawnedBullet = Instantiate(bulletPrefub, firePosition.transform.position, firePosition.rotation);
        Bullet bullet = spawnedBullet.GetComponent<Bullet>();
        if(bullet != null)
        {
            bullet.Seek(_target);
        }
    }

    private void GetInTarget()
    {
        Vector3 dir = _target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation  = Quaternion.Lerp(_partToRotate.rotation, lookRotation, Time.deltaTime * _turnSpeed).eulerAngles;
        _partToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f);
    }

    private void UpdateTarget()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag(_enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject neatestEnemy = null;

        foreach (var enemy in enemys)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                neatestEnemy = enemy;
            }
        }

        if(neatestEnemy !=null && shortestDistance <= Range)
        {
            _target = neatestEnemy.transform;
            _enemy = _target.GetComponent<Enemy>();
        }
        else
        {
            _target = null;
        }
    }

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
