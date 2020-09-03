using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class HitGlow : HitEvent
{
    [SerializeField] private float _colorHoldTime;
    [SerializeField] private Color _hitColor;
    //[SerializeField] private Color _deathColor;

    private Color _normalColor;
    private SpriteRenderer _sprite;
    private WaitForSeconds wait;
    protected override void Start()
    {
        base.Start();

        _sprite = GetComponent<SpriteRenderer>();
        _normalColor = _sprite.color;

        wait = new WaitForSeconds(_colorHoldTime);
    }

    protected override void Hit()
    {
        StartCoroutine(HitRoutine());
    }

    private IEnumerator HitRoutine()
    {
        _sprite.color = _hitColor;
        yield return wait;
        _sprite.color = _normalColor;
    }
}