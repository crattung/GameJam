using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickThrow : MonoBehaviour
{
    public float throwPower = 80f;
    public float pickupDistance = 2;

    [SerializeField] private GameObject _stickPrefab; //SerializeField makes private fields show up in inspector
    [SerializeField] private float _rotationSpeed = 30f;

    private Camera _mainCam;
    private Transform _stickThrown;
    private Animator _anim;

    void Start()
    {
        _mainCam = Camera.main;
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        var dir = Dir();

        if(Input.GetButtonDown("Fire1"))
        {    
            if (_anim)
            {
                _anim.SetFloat("horizontal", dir.x);
                _anim.SetFloat("vertical", dir.y);
            }

            if(_stickThrown)
            {
                if(Vector2.Distance(transform.position, _stickThrown.position) < pickupDistance)
                {
                    Destroy(_stickThrown.gameObject);
                    _stickThrown = null;
                    _anim?.SetBool("HasStick", true);
                }
            }
            else
            {                
                _anim?.SetTrigger("Attack");
            }
        }
    }

    public void Throw()
    {
        if(_stickThrown)
            return;
            
        var dir = Dir();
        var stick = Instantiate(_stickPrefab, transform.position,
                Quaternion.Euler(Vector3.forward * (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90f))) //makes the stick face forward when shot
            .GetComponent<Rigidbody2D>();
        stick.AddForce(dir * throwPower);
        stick.AddTorque(_rotationSpeed);

        _stickThrown = stick.transform;
        _anim?.SetBool("HasStick", false);       

    }

    private Vector2 Dir() => ((Vector2)(_mainCam.ScreenToWorldPoint(Input.mousePosition) - transform.position)).normalized;
}
