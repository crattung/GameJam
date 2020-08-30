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

    private Transform _player;
    private Health _health;
    private Rigidbody2D _rb;
    void Start()
    {
        _health = GetComponent<Health>();
        _health.deathEvent += Dead;

        _rb = GetComponent<Rigidbody2D>();

        _player = GameObject.FindGameObjectWithTag("Player").transform;
        if(!_player)
            Debug.LogError("No player with tag \"Player\" found");

    }

    private void Dead()
    {
        _health.deathEvent -= Dead;
        Debug.Log($"{gameObject.name} died.");
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        //_rb.velocity = Vector2.zero;
        var diff = (_player.position - transform.position);
        if(_hitDistance < diff.magnitude)
        {    
            var dir = (Vector2)diff.normalized;
            _rb.MovePosition((Vector2)transform.position + (_moveSpeed * dir * Time.fixedDeltaTime));
        }
    }
}
