using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Health : MonoBehaviour
{
    [SerializeField] private int _health = 1;
    public Action deathEvent;

    public void Damage(int dmg = 1)
    {
        _health -= dmg;
        if(_health < 1)
        {
            deathEvent?.Invoke();
        }
    }

}
