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

    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.name + $": {_stickingTags.Any(col.gameObject.tag.Contains)}");
        if(_stickingTags.Any(col.gameObject.tag.Contains)) //for each string in _stickingTags, check if the collided object's tag contain the string
        {
            _rb.velocity = Vector3.zero;
            _rb.angularVelocity = 0f;
        }
    }
}
