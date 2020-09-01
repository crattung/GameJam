using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Health : MonoBehaviour
{
    [SerializeField] private int _health = 1;
    public UnityEvent deathEvent;
    public UnityEvent hitEvent;

    public void Damage(int dmg = 1)
    {
        _health -= dmg;
        hitEvent?.Invoke();
        if(_health < 1)
        {
            deathEvent?.Invoke();
        }
    }

}
