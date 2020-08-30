using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class StickStick : MonoBehaviour
{
    [Tooltip("tag of objects to stick to")]
    [SerializeField]
    private string[] _stickingTags = { "Sticker" };
    [SerializeField]
    private float _damageVelocity = 20f;

    [Header("Debug")]
    [SerializeField]
    private bool bounced = false;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(_stickingTags.Any(col.gameObject.tag.Contains)) //for each string in _stickingTags, check if the collided object's tag contain the string
        {
            _rb.velocity = Vector3.zero;
            _rb.angularVelocity = 0f;
        }
        else
        {
            bounced = true;
        }

        DamageCheck(col.gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(bounced)
            DamageCheck(col.gameObject);
    }

    void DamageCheck(GameObject go)
    {
        if (_rb.velocity.sqrMagnitude > _damageVelocity)
        {
            var health = go.GetComponent<Health>();
            if (health)
            {
                health.Damage();
            }
        }
    }

#if UNITY_EDITOR
    void Update()
    {
        //Debug.Log(_rb.velocity.sqrMagnitude);
    }
#endif
}
