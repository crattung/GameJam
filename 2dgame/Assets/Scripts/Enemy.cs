using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 6f;
    [SerializeField]
    private float _hitDistance = 2f;
    [SerializeField]
    private float _hitInterval = 2f;

    private Health _playerHealth;
    private Health _health;
    private Rigidbody2D _rb;
    private float _hitTime;
    void Start()
    {
        _health = GetComponent<Health>();
        _health.deathEvent.AddListener(Dead);

        _rb = GetComponent<Rigidbody2D>();

        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        if(!_playerHealth)
            Debug.LogError("No player with tag \"Player\" found");

    }

    private void Dead()
    {
        GameManager.instance.score++;
        _health.deathEvent.RemoveListener(Dead);
        //Debug.Log($"{gameObject.name} died.");
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        if(_playerHealth)
        {    
            //_rb.velocity = Vector2.zero;
            var diff = (_playerHealth.transform.position - transform.position);
            if(_hitDistance < diff.magnitude)
            {    
                var dir = (Vector2)diff.normalized;
                _rb.MovePosition((Vector2)transform.position + (_moveSpeed * dir * Time.fixedDeltaTime));
            }
            else
            {
                if(_hitTime < Time.time)
                {
                    _playerHealth.Damage();
                    _hitTime = Time.time + _hitInterval;
                }
            }
        }
    }
}
