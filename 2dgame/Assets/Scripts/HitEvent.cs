using UnityEngine;

[RequireComponent(typeof(Health))]
public abstract class HitEvent : MonoBehaviour
{
    protected virtual void Start()
    {
        var health = GetComponent<Health>();
        health.hitEvent.AddListener(Hit);
        health.deathEvent.AddListener(Dead);
    }

    protected virtual void Dead(){}

    protected virtual void Hit(){}
}