using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    [SerializeField] GameObject _ball;
    [SerializeField] float _moveTowardsSpeed;

    [SerializeField] CollisionController _collisionController;
    [SerializeField] BallController _ballController;

    Rigidbody _rigidbody;
    private float distanceToStop = 0f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collisionController = FindObjectOfType<CollisionController>();
        _ballController = FindObjectOfType<BallController>();
    }

    private void Update()
    {
        if (_ballController._thrown == true)
        {
            MoveTowardsWithRotation(_ball.transform, distanceToStop, _moveTowardsSpeed);
        }
    }

    private void MoveTowardsWithRotation(Transform _ball, float distanceToStop, float _moveTowardsSpeed)
    {
        if (_collisionController._collided == false)
        {
            if(Vector3.Distance(transform.position, _ball.position) > distanceToStop)
            {
                transform.LookAt(_ball);
                _rigidbody.AddRelativeForce(Vector3.forward * _moveTowardsSpeed, ForceMode.Force);
                _collisionController._collided = true;
            }

           
           
        }
    }
}
