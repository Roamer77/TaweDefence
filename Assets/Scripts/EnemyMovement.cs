using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform _targer;

    private int _wayPointIndex = 0;

    private Enemy _enemy;

    void Start()
    {
        _enemy = GetComponent<Enemy>();
        _targer = Waypoints.points[0];
    }

    void Update()
    {
        Vector3 dir = _targer.position - transform.position;
        transform.Translate(dir.normalized * _enemy.Speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, _targer.position) <= 0.6f)
        {
            GetNextPosition();
        }
        _enemy.Speed = _enemy.StartSpeed;
    }

    private void GetNextPosition()
    {
        if (_wayPointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        _wayPointIndex++;
        _targer = Waypoints.points[_wayPointIndex];
    }

    private void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemysAlive --;
        Destroy(gameObject);
    }
}
