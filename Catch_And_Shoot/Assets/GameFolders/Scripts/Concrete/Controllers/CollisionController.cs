using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    [SerializeField] BallController _ball;

    [SerializeField] GameObject _player2RightHand;

    public bool _collided = false;

    Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _ball = GetComponent<BallController>();
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("COLLISION");

        if (other.gameObject.tag == "Player")
        {
            _collided = true;
            _ball._thrown = false;
            _rigidbody.useGravity = false;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
            Debug.Log("Hit Player tag");

            _rigidbody.transform.position = _player2RightHand.transform.position;
        }
    }
}
