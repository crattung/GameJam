using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : HitEvent
{
    [SerializeField] private Image _healthbar;

    private Health _health;
    private int _maxHealth;
    protected override void Start()
    {
        base.Start();

        _health = GetComponent<Health>();
        _maxHealth = _health.GetHP();
    }

    protected override void Hit()
    {
        _healthbar.fillAmount = (float)_health.GetHP() / _maxHealth;
    }
}