using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] GameObject _playerRightHand;
    [SerializeField] Vector3 _ballPosition;

    CollisionController _collisionController;

    public float _throwSpeedZ, _throwSpeedY;

    public bool _thrown = false;

    
    

    Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collisionController = GetComponent<CollisionController>();
    }

    private void Update()
    {
        _rigidbody.useGravity = false;

        if (Input.GetMouseButtonUp(0))
        {
            _thrown = true;
        }
    }

    private void FixedUpdate()
    {
        if (_thrown == false && _collisionController._collided == false)
        {
            transform.position = _playerRightHand.transform.position + _ballPosition;
        }

        if (_thrown)
        {
            _rigidbody.useGravity = true;
            _rigidbody.velocity += (Vector3.forward * _throwSpeedZ * Time.deltaTime);
            _rigidbody.velocity += (Vector3.up * _throwSpeedY * Time.deltaTime);

        }
    }
}
